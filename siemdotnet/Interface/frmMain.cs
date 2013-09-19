using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Management.Automation;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace psframework
{
    public partial class frmMain : Form
    {
        #region Private Variables 
        Network.NetworkBrowser scnr = new Network.NetworkBrowser();
        private int mincurpos = 6;
        private Collection<String> cmdhist = new Collection<string>();
        private int cmdhistidx = -1;
        private PShell.pshell psf = new PShell.pshell();

        enum SystemType
        { 
            Local = 1,
            Domain
        }

        enum LibraryImages
        { 
            Function,
            Cmdlet,
            Command,
            Alias
        }
        #endregion

        #region Form
        public frmMain()
        {
            InitializeComponent();
            txtPShellOutput.SelectionStart = mincurpos;
            scnr.ParentForm = this;
            cmbLibraryTypes.SelectedIndex = 1;
            psf.ParentForm = this;
            GetNetworks();
            GetLibrary();
            GetCommand();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (lvwActiveScripts.Items.Count > 0)
                {
                    if (MessageBox.Show("You have active scripts running. If you exit, all running scripts will be terminated. Are you sure you want to exit?", "Active Scripts", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        foreach (ListViewItem lvw in lvwActiveScripts.Items)
                        {
                            Thread thd = (Thread)lvw.Tag;
                            thd.Abort();
                            do
                            {
                                Application.DoEvents();
                            } while (thd.ThreadState != ThreadState.Aborted);
                        }
                        this.Close();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception)
            { 
                //just exit.
                this.Close();
            }
        }
        #endregion

        #region Private Methods

        #region Network
        private void GetNetworks()
        {
            try
            {
                //Get Domain Name
                Forest hostForest = Forest.GetCurrentForest();
                DomainCollection domains = hostForest.Domains;
                /*
                foreach (Domain domain in domains)
                {
                    TreeNode node = new TreeNode();
                    node.Text = domain.Name;
                    node.SelectedImageIndex = 3;
                    node.ImageIndex = 3;
                    node.Tag = SystemType.Domain;
                    TreeNode rootnode = tvwNetworks.Nodes[0];
                    rootnode.Nodes.Add(node);
                }*/
            }
            catch
            {
                //fail silently because it's not on A/D   
            }

            try
            {
                //Add Local IP/Host to Local Network
                String localHost = Dns.GetHostName();
                String localIP = scnr.GetIP(localHost);

                ListViewItem lvwItm = new ListViewItem();

                //lvwItm.Text = localHost;
                //lvwItm.SubItems.Add(localIP);
                lvwItm.Text = "localhost";
                lvwItm.SubItems.Add("[hidden]");
                lvwItm.SubItems.Add("00-00-00-00-00-00");
                lvwItm.SubItems.Add("Up");
                lvwItm.SubItems.Add("Not Installed");
                lvwItm.SubItems.Add("0");
                lvwItm.SubItems.Add(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));

                lvwItm.ImageIndex = 2;
                lvwSystems.Items.Add(lvwItm);
                lvwSystems.Refresh();

                tvwNetworks.Nodes[0].Expand();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + Environment.NewLine + e.StackTrace);
            }
        }

        private void Scan()
        {
            lvwSystems.Items.Clear();
            if (tvwNetworks.SelectedNode != null && tvwNetworks.SelectedNode.Tag != null)
            {
                SystemType typ = (SystemType)Enum.Parse(typeof(SystemType), tvwNetworks.SelectedNode.Tag.ToString());
                switch (typ)
                {
                    case SystemType.Local:
                        ScanbyIP();
                        break;
                    case SystemType.Domain:
                        ScanAD();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select a network first.");
            }
        }

        private void ScanAD()
        {
            String domain = tvwNetworks.SelectedNode.Text;
            ArrayList rslts = scnr.ScanActiveDirectory(domain);
            if (rslts.Count > 0)
            {
                foreach (DirectoryEntry system in rslts)
                {
                    ListViewItem lvwItm = new ListViewItem();
                    lvwItm.Text = system.Name.ToString();

                    String ipadr = scnr.GetIP(system.Name);
                    lvwItm.SubItems.Add(ipadr);
                    lvwItm.SubItems.Add("00-00-00-00-00-00");
                    bool isup = false;
                    if (ipadr != "0.0.0.0 (unknown host)")
                    {
                        isup = scnr.Ping(system.Name, 1, 500);
                    }
                    if (isup)
                    {
                        lvwItm.SubItems.Add("Up");
                    }
                    else
                    {
                        lvwItm.SubItems.Add("Down");
                    }
                    lvwItm.SubItems.Add("Not Installed");
                    lvwItm.SubItems.Add("0");
                    lvwItm.SubItems.Add(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));

                    lvwItm.ImageIndex = 2;
                    lvwSystems.Items.Add(lvwItm);
                    lvwSystems.Refresh();
                    Application.DoEvents();
                }
            }

            rslts = null;
        }

        private void ScanbyIP()
        {
            lvwSystems.Items.Clear();            
            ArrayList rslts = scnr.ScanbyIP();
            if (rslts.Count > 0)
            {
                SetProgress(0, rslts.Count);
                foreach (String system in rslts)
                {
                    ListViewItem lvwItm = new ListViewItem();
                    
                    SetStatus("Adding " + system + ", please wait...");
                    
                    lvwItm.Text = scnr.GetHostname(system);
                    lvwItm.SubItems.Add(system);
                    lvwItm.SubItems.Add("00-00-00-00-00-00");
                    lvwItm.SubItems.Add("Up");
                    lvwItm.SubItems.Add("Not Installed");
                    lvwItm.SubItems.Add("0");
                    lvwItm.SubItems.Add(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));

                    lvwItm.ImageIndex = 2;
                    lvwSystems.Items.Add(lvwItm);
                    lvwSystems.Refresh();

                    pbStatus.Value += 1;
                    Application.DoEvents();
                }
            }

            rslts = null;
            HideProgress();
            lblStatus.Text = "Ready";
        }

        private void RunScript()
        {
            if (lvwScripts.SelectedItems.Count > 0)
            {
                ListViewItem lvw = lvwScripts.SelectedItems[0];
                //This needs to be a separate runspace.
                PShell.pshell ps = new PShell.pshell();
                ps.ParentForm = this;
                ps.Run(lvw.Text);
                ps = null;
            }
        }

        private void ViewScript()
        {
            if (lvwScripts.SelectedItems.Count > 0)
            {
                ListViewItem lvw = lvwScripts.SelectedItems[0];
                String script = (String)lvw.Tag;
                if (File.Exists(script))
                {
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(script);
                    psi.UseShellExecute = true;
                    psi.Verb = "open";
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    prc.StartInfo = psi;
                    prc.Start();
                    prc = null;
                }
            }
        }
        #endregion

        #region Status
        public void SetStatus(String message)
        {
            lblStatus.Text = message;
            Application.DoEvents();
        }
        #endregion

        #region ProgressBar
        public void SetProgress(int Value, int Maximum)
        {
            pbStatus.Visible = true;
            if (pbStatus.Maximum != Maximum)
            {
                pbStatus.Maximum = Maximum;
            }
            if (Value <= Maximum)
            {
                pbStatus.Value = Value;            
            }
        }

        public void HideProgress()
        {
            pbStatus.Visible = false;
        }
        #endregion

        #region "PowerShell"
        public void DisplayOutput(String output, ListViewItem lvw, bool clicked, bool cancelled = false)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate
                {
                    DisplayOutput(output, lvw, clicked, cancelled);
                };
                this.Invoke(del);
            }
            else
            {
                if ((txtPShellOutput.Text.Length + output.Length + (Environment.NewLine + "psf > ").Length) > txtPShellOutput.MaxLength)
                {
                    txtPShellOutput.Text = txtPShellOutput.Text.Substring(output.Length + 500, txtPShellOutput.Text.Length - (output.Length + 500));
                }
                txtPShellOutput.AppendText(output);
                txtPShellOutput.AppendText(Environment.NewLine + "psf > ");
                mincurpos = txtPShellOutput.Text.Length;
                if (clicked || cancelled)
                {
                    //Not sure why this happens, but if you type the command the scroll to caret isn't needed.
                    //If you initiate a script or command by double clicking, or you abort the thread, you do.
                    txtPShellOutput.ScrollToCaret();
                }
                txtPShellOutput.ReadOnly = false;
                if (lvw != null)
                {
                    lvw.Remove();
                }                
            }            
        }

        public void AddAlert(String message, PShell.psmethods.PSAlert.AlertType alerttype, String scriptname)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate
                {
                    AddAlert(message, alerttype, scriptname);
                };
                this.Invoke(del);
            }
            else 
            {
                try
                {
                    ListViewItem lvwitm = new ListViewItem();
                    lvwitm.Text = alerttype.ToString();
                    lvwitm.ImageIndex = (int)alerttype;
                    lvwitm.SubItems.Add(message);
                    lvwitm.SubItems.Add(scriptname);
                    lvwAlerts.Items.Add(lvwitm);
                    lvwAlerts_Update();
                }
                catch (Exception e)
                {
                    DisplayError(e);
                }                
            }
        }

        public void UpdateStatus(String message, ListViewItem lvw)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate
                {
                    UpdateStatus(message, lvw);
                };
                this.Invoke(del);
            }
            else
            {
                try
                {
                    lvw.SubItems[1].Text = message;
                    lvwScripts.Refresh();
                }
                catch (Exception e)
                {
                    DisplayError(e);
                }
            }
        }

        public void AddActiveScript(ListViewItem lvw)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate
                {
                    AddActiveScript(lvw);
                };
                this.Invoke(del);
            }
            else
            {
                lvwActiveScripts.Items.Add(lvw);
            }
        }

        private void ProcessCommand(String cmd)
        {
            try
            {
                cmdhist.Add(cmd);
                cmdhistidx = cmdhist.Count;
                switch (cmd.ToUpper())
                { 
                    case "CLS":
                        txtPShellOutput.Text = "psf > ";
                        txtPShellOutput.SelectionStart = txtPShellOutput.Text.Length;
                        mincurpos = txtPShellOutput.Text.Length;
                        break;
                    case "EXIT":
                        this.Close();
                        break;
                    default:
                        txtPShellOutput.AppendText(Environment.NewLine);
                        mincurpos = txtPShellOutput.Text.Length;
                        txtPShellOutput.ReadOnly = true;
                        psf.Run(cmd, true, false);
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ProcessCommand Unhandled Exception: " + e.Message + Environment.NewLine + "Stack Trace:" + Environment.NewLine);
            }
        }

        private void GetCommand()
        {
            try
            {
                PShell.pscript ps = new PShell.pscript();
                Collection<PSObject> rslt = ps.GetCommand();
                ps = null;
                if (rslt != null)
                {
                    lvwCommands.Items.Clear();
                    lvwCommands.BeginUpdate();
                    foreach (PSObject po in rslt)
                    {
                        ListViewItem lvw = null;
                        switch (po.BaseObject.GetType().Name)
                        {
                            case "AliasInfo":
                                AliasInfo ai = (AliasInfo)po.BaseObject;
                                if (btnShowAliases.Checked)
                                {
                                    lvw = new ListViewItem();
                                    lvw.Text = ai.Name;
                                    lvw.ToolTipText = ai.Name;
                                    lvw.SubItems.Add(ai.ModuleName);
                                    lvw.ImageIndex = (int)LibraryImages.Alias;
                                }
                                break;
                            case "FunctionInfo":
                                FunctionInfo fi = (FunctionInfo)po.BaseObject;
                                if (btnShowFunctions.Checked)
                                {
                                    lvw = new ListViewItem();
                                    lvw.Text = fi.Name;
                                    lvw.ToolTipText = fi.Name;
                                    lvw.SubItems.Add(fi.ModuleName);
                                    lvw.ImageIndex = (int)LibraryImages.Function;
                                }
                                break;
                            case "CmdletInfo":
                                CmdletInfo cmi = (CmdletInfo)po.BaseObject;
                                if (btnShowCmdlets.Checked)
                                {
                                    lvw = new ListViewItem();
                                    lvw.Text = cmi.Name;
                                    lvw.ToolTipText = cmi.Name;
                                    lvw.SubItems.Add(cmi.ModuleName);
                                    lvw.ImageIndex = (int)LibraryImages.Cmdlet;
                                }
                                break;
                            default:
                                Console.WriteLine(po.BaseObject.GetType().Name);
                                break;
                        }
                        if (lvw != null && (cmbLibraryTypes.Text == "All" || cmbLibraryTypes.Text == lvw.SubItems[1].Text))
                        {
                            lvwCommands.Items.Add(lvw);
                        }
                        else
                        {
                            lvw = null;
                        }
                    }
                    lvwCommands.EndUpdate();
                }
            }
            catch (Exception e)
            {
                DisplayError(e);
            }
        }

        private void GetLibrary()
        {
            try
            {
                String scriptroot = "C:\\pstest\\"; // Get this variable from Settings.
                String[] scpaths = Directory.GetFiles(scriptroot, "*.ps1", SearchOption.TopDirectoryOnly);
                if (scpaths != null)
                {
                    lvwScripts.BeginUpdate();
                    lvwScripts.Items.Clear();
                    foreach (String scpath in scpaths)
                    { 
                        ListViewItem lvw = new ListViewItem();
                        lvw.Text = new FileInfo(scpath).Name;
                        lvw.ImageIndex = 4;
                        lvw.Tag = scpath;
                        lvwScripts.Items.Add(lvw);
                    }
                    lvwScripts.EndUpdate();
                }
            }
            catch (Exception e)
            {
                DisplayError(e);
            }
        }
        #endregion

        #region " Display Error "
        private void DisplayError(Exception e)
        {
            DisplayOutput(Environment.NewLine + "Unhandled exception." + Environment.NewLine + e.Message + Environment.NewLine + "Stack Trace:" + Environment.NewLine + e.StackTrace, null, true);
            tcMain.SelectedTab = tbpPowerShell;
        }
        #endregion

        #endregion

        #region Private Events

        #region Menu Clicks
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void mnuScan_Click(object sender, EventArgs e)
        {
            Scan();
        }
        #endregion 

        #region List View
        private void lvwAlerts_Update()
        {
            tbpAlerts.Text = "Alerts (" + lvwAlerts.Items.Count.ToString() + ")";
        }

        private void lvwScripts_DoubleClick(object sender, EventArgs e)
        {
            RunScript();
        }

        private void lvwCommands_DoubleClick(object sender, EventArgs e)
        {
            if (lvwCommands.SelectedItems.Count > 0)
            {
                ListViewItem lvw = lvwCommands.SelectedItems[0];
                psf.Run(lvw.Text, true);
            }
        }

        private void lvwScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwScripts.SelectedItems.Count > 0)
            {
                btnViewScript.Enabled = true;
                btnRunScript.Enabled = true;
            }
            else
            {
                btnViewScript.Enabled = false;
                btnRunScript.Enabled = false;
            }
        }
        #endregion

        #region TextBox
        private void txtPShellOutput_KeyDown(object sender, KeyEventArgs e)
        {
            //This code is required to emulate a powershell command prompt.
            //otherwise it's just a textbox.
            switch (e.KeyCode)
            { 
                case Keys.Back:
                    if (txtPShellOutput.SelectionStart <= mincurpos)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    break;
                case Keys.Delete:
                    if (txtPShellOutput.SelectionStart < mincurpos)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    break;
                case Keys.Left:
                    if (txtPShellOutput.SelectionStart <= mincurpos)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        txtPShellOutput.SelectionStart = mincurpos;                    
                    }
                    break;
                case Keys.Home:
                    e.Handled = true;
                    e.SuppressKeyPress = true;                   
                    txtPShellOutput.SelectionStart = mincurpos;
                    txtPShellOutput.ScrollToCaret();
                    break;
                case Keys.End:
                    e.Handled = true;
                    e.SuppressKeyPress = true;                   
                    txtPShellOutput.SelectionStart = txtPShellOutput.Text.Length;
                    txtPShellOutput.ScrollToCaret();
                    break;
                case Keys.Enter:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    String cmd = txtPShellOutput.Text.Substring(mincurpos, txtPShellOutput.Text.Length - mincurpos);
                    ProcessCommand(cmd);
                    break;
                case Keys.ControlKey: case Keys.Alt:
                    e.SuppressKeyPress = false;
                    e.Handled = false;
                    break;
                case Keys.Up:                    
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    if (cmdhist != null && cmdhist.Count > 0)
                    {
                        if (cmdhistidx <= cmdhist.Count && cmdhistidx > 0)
                        {
                            cmdhistidx -= 1;
                            txtPShellOutput.Text = txtPShellOutput.Text.Substring(0, mincurpos);
                            txtPShellOutput.AppendText(cmdhist[cmdhistidx]);
                            txtPShellOutput.SelectionStart = txtPShellOutput.Text.Length;
                        }
                    }
                    break;
                case Keys.Down:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    if (cmdhist != null && cmdhist.Count > 0)
                    {                       
                        if (cmdhistidx >= 0 && cmdhistidx < cmdhist.Count - 1)
                        {
                            cmdhistidx += 1;
                            txtPShellOutput.Text = txtPShellOutput.Text.Substring(0, mincurpos);
                            txtPShellOutput.AppendText(cmdhist[cmdhistidx]);
                            txtPShellOutput.SelectionStart = txtPShellOutput.Text.Length;
                            
                        }
                        else 
                        {
                            txtPShellOutput.Text = txtPShellOutput.Text.Substring(0, mincurpos);
                            txtPShellOutput.SelectionStart = txtPShellOutput.Text.Length;
                            cmdhistidx = cmdhist.Count;
                        }
                    }
                    break;
                case Keys.L: case Keys.C: case Keys.X: case Keys.V:
                    if (e.Control)
                    {
                        switch (e.KeyCode)
                        { 
                            case Keys.L:
                                //Ctrl+L for CLS!
                                e.Handled = true;
                                e.SuppressKeyPress = true;
                                txtPShellOutput.Text = "psf > ";
                                mincurpos = txtPShellOutput.Text.Length;
                                txtPShellOutput.ScrollToCaret();
                                break;
                            default:
                                e.Handled = false;
                                e.SuppressKeyPress = false;
                                break;
                        }                        
                    }
                    break;
                default:
                    if (txtPShellOutput.SelectionStart < mincurpos)
                    {
                        txtPShellOutput.SelectionStart = txtPShellOutput.Text.Length;
                        txtPShellOutput.ScrollToCaret();
                    }
                    break;
            }
        }
        #endregion

        #region Button Clicks
        private void btnLibraryRefresh_Click(object sender, EventArgs e)
        {
            GetCommand();
        }

        private void btnShowAliases_Click(object sender, EventArgs e)
        {
            btnShowAliases.Checked = !btnShowAliases.Checked;
            GetCommand();
        }

        private void btnShowFunctions_Click(object sender, EventArgs e)
        {
            btnShowFunctions.Checked = !btnShowFunctions.Checked;
            GetCommand();
        }

        private void btnShowCmdlets_Click(object sender, EventArgs e)
        {
            btnShowCmdlets.Checked = !btnShowCmdlets.Checked;
            GetCommand();
        }

        private void cmnuActiveScripts_Opening(object sender, CancelEventArgs e)
        {
            if (lvwActiveScripts.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void cmnuScripts_Opening(object sender, CancelEventArgs e)
        {
            if (lvwScripts.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void cmbtnCancelScript_Click(object sender, EventArgs e)
        {
            if (lvwActiveScripts.SelectedItems.Count > 0)
            {
                ListViewItem lvw = lvwActiveScripts.SelectedItems[0];
                Thread thd = (Thread)lvw.Tag;
                thd.Abort();
                lvw.SubItems[1].Text = "Aborting... ThreadState = " + thd.ThreadState.ToString();
            }
            else
            {
                MessageBox.Show("Please select an active script.");
            }
        }

        private void btnClearAlerts_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all of the alerts?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                lvwAlerts.Items.Clear();
                lvwAlerts_Update();
            }
        }

        private void btnRefreshScripts_Click(object sender, EventArgs e)
        {
            GetLibrary();
        }

        private void btnViewScript_Click(object sender, EventArgs e)
        {
            ViewScript();
        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            RunScript();
        }

        private void cmbtnRunScript_Click(object sender, EventArgs e)
        {
            RunScript();
        }

        private void cmbtnViewScript_Click(object sender, EventArgs e)
        {
            ViewScript();
        }
        #endregion

        #region ComboBox Events
        private void cmbLibraryTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCommand();
        }
        #endregion

        private void tcMain_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tbpPowerShell)
            {
                txtPShellOutput.Select();
            }
        }

        #endregion
    }
}