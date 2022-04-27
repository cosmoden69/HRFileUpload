using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YLWService;

namespace HRFileUpload
{
    public partial class frmFileUpload : Form
    {
        public frmFileUpload()
        {
            InitializeComponent();

            btnOpenFolder.Click += BtnOpenFolder_Click;
            btnUploadStart.Click += BtnUploadStart_Click;

            string userRoot = System.Environment.GetEnvironmentVariable("USERPROFILE");
            txtFolderPath.Text = Path.Combine(userRoot, "Downloads", "Upload");
        }

        private void ClearSceen()
        {
            txtTotalCnt.Text = "";
            txtUpCnt.Text = "";
            txtUpMsg.Text = "";
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.SelectedPath = txtFolderPath.Text;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtFolderPath.Text = dlg.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUploadStart_Click(object sender, EventArgs e)
        {
            string path = txtFolderPath.Text;
            if (!Directory.Exists(path))
            {
                MessageBox.Show("업로드할 파일이 있는 폴더를 선택하세요");
                return;
            }

            try
            {
                btnUploadStart.Enabled = false;
                Cursor = Cursors.WaitCursor;

                var files = Directory.GetFiles(path, "*.*");
                txtTotalCnt.Text = Utils.ConvertToString(files?.Length);
                txtUpCnt.Text = "";
                Application.DoEvents();
                foreach (var file in files)
                {
                    try
                    {
                        txtUpMsg.Text = "Read File : " + Path.GetFileName(file);
                        Application.DoEvents();

                        //압축파일이면 따로 처리
                        string ext = Path.GetExtension(file);
                        if (ext.ToUpper() == ".ZIP")
                        {
                            if (fnUploadZipFile(file) == false) continue;  //압축파일 업로드 실패

                            File.Delete(file);
                            txtUpCnt.Text = Utils.ConvertToString(Utils.ToInt(txtUpCnt.Text) + 1);
                            Application.DoEvents();
                            continue;
                        }

                        string filename = Path.GetFileNameWithoutExtension(file);
                        string empid = Utils.GetP(filename, "_", 1);
                        string ftype = Utils.GetP(filename, "_", 2);
                        string upname = Utils.GetP(filename, "_", 3);
                        if (fnFileUpload(file, empid, ftype, upname) == false) continue;

                        File.Delete(file);
                        txtUpCnt.Text = Utils.ConvertToString(Utils.ToInt(txtUpCnt.Text) + 1);
                        Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        txtUpMsg.Text = ex.Message;
                        YLWService.LogWriter.WriteLog(ex.Message);
                        string filepath = Path.GetDirectoryName(file);
                        filepath = Path.Combine(filepath, "Error_backup");
                        if (!Directory.Exists(filepath)) Directory.CreateDirectory(filepath);
                        string tofile = Path.Combine(filepath, Path.GetFileName(file));
                        FileMoveTo(file, filepath);
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnUploadStart.Enabled = true;
            }
        }

        private bool fnUploadZipFile(string zipFile)
        {
            try
            {
                string zipPath = Path.GetDirectoryName(zipFile);
                string zipFilename = Path.GetFileNameWithoutExtension(zipFile);
                zipPath = Path.Combine(zipPath, zipFilename);
                if (!Directory.Exists(zipPath)) Directory.CreateDirectory(zipPath);
                Utils.ClearFolder(zipPath);
                Utils.ZipExtract(zipFile, zipPath);
                var files = Directory.GetFiles(zipPath, "*.*");
                foreach (var file in files)
                {
                    try
                    {
                        string ftype = zipFilename;
                        string filename = Path.GetFileNameWithoutExtension(file);
                        string empid = Utils.GetP(filename, "_", 1);
                        string upname = Utils.GetP(filename, "_", 2);
                        if (fnFileUpload(file, empid, ftype, upname) == false) continue;

                        File.Delete(file);
                        txtUpCnt.Text = Utils.ConvertToString(Utils.ToInt(txtUpCnt.Text) + 1);
                        Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        txtUpMsg.Text = ex.Message;
                        YLWService.LogWriter.WriteLog(ex.Message);
                        string filepath = Path.GetDirectoryName(file);
                        filepath = Path.Combine(filepath, "Error_backup");
                        if (!Directory.Exists(filepath)) Directory.CreateDirectory(filepath);
                        string tofile = Path.Combine(filepath, Path.GetFileName(file));
                        FileMoveTo(file, filepath);
                        Application.DoEvents();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool fnFileUpload(string file, string empid, string ftype, string upname)
        {
            try
            {
                if (empid == "") return false;
                string empSeq = fnGetEmpSeq(empid);
                if (empSeq == "") return false;

                string fileConstSeq = "1";
                string fileSeq = "0";
                string idxNo = "1";
                switch (ftype.ToUpper())
                {
                    case "주민등록등본":
                        fileSeq = fnGetFileSeq(ftype, empSeq, "1;0;0;0;0;0;0;0;0");
                        break;
                    case "통장사본":
                        fileSeq = fnGetFileSeq(ftype, empSeq, "0;1;0;0;0;0;0;0;0");
                        break;
                    case "차량유지비":
                        fileSeq = fnGetFileSeq(ftype, empSeq, "0;0;1;0;0;0;0;0;0");
                        break;
                    case "육아수당":
                        fileSeq = fnGetFileSeq(ftype, empSeq, "0;0;0;1;0;0;0;0;0");
                        break;
                    case "졸업증명":
                        fileSeq = fnGetFileSeq(ftype, empSeq, "0;0;0;0;1;0;0;0;0");
                        break;
                    case "성적증명":
                        fileSeq = fnGetFileSeq(ftype, empSeq, "0;0;0;0;0;1;0;0;0");
                        break;
                    case "경력":
                        //fileSeq = fnGetFileSeq(ftype, empSeq, "0;0;0;0;0;0;1;0;0");
                        break;
                    case "자격면허":
                        //fileSeq = fnGetFileSeq(ftype, empSeq, "0;0;0;0;0;0;0;1;0");
                        break;
                    case "어학시험":
                        //fileSeq = fnGetFileSeq(ftype, empSeq, "0;0;0;0;0;0;0;0;1");
                        break;
                    default:
                        return false;
                }
                fileSeq = fnFileUpload(fileConstSeq, fileSeq, idxNo, upname, file);
                if (!fnSaveHRTables(ftype, empSeq, fileSeq, upname)) return false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string fnGetEmpSeq(string empId)
        {
            try
            {
                YLWService.YlwSecurityJson security = YLWService.MTRServiceModule.SecurityJson.Clone();  //깊은복사

                string strSql = "";
                strSql += " SELECT emp.EmpSeq, emp.EmpName ";
                strSql += " FROM   _TDAEmp AS emp WITH(NOLOCK) ";
                strSql += " WHERE  emp.CompanySeq = '" +  Utils.ConvertToString(security.companySeq) + "' ";
                strSql += " AND    emp.Empid = '" + empId + "' ";
                strSql += " FOR JSON PATH ";
                DataTable dtr = YLWService.MTRServiceModule.GetMTRServiceDataTable(security.companySeq, strSql);
                if (dtr != null && dtr.Rows.Count > 0) return Utils.ConvertToString(dtr.Rows[0]["EmpSeq"]);
                throw new Exception("사번[" + empId + "]의 EmpSeq를 찾을 수 없습니다");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string fnGetFileSeq(string fileType, string empSeq, string fileSelect)
        {
            try
            {
                YLWService.YlwSecurityJson security = YLWService.MTRServiceModule.SecurityJson.Clone();  //깊은복사
                security.serviceId = "Metro.Package.AdjHR.BisEmpAttachMng";
                security.methodId = "QueryFile";

                DataSet ds = new DataSet("ROOT");
                DataTable dt = ds.Tables.Add("DataBlock1");
                dt.Columns.Add("EmpSeq");
                dt.Columns.Add("FileSelect");
                dt.Clear();
                DataRow dr = dt.Rows.Add();
                dr["EmpSeq"] = empSeq;
                dr["FileSelect"] = fileSelect;

                DataSet yds = YLWService.MTRServiceModule.CallMTRServiceCallPost(security, ds);
                if (yds == null || yds.Tables.Count < 1) return "0";
                DataTable ydt = yds.Tables[0];
                if (ydt == null || ydt.Rows.Count < 1) return "0";
                if (fileType != ydt.Rows[0]["FileType"] + "") return "0";
                return ydt.Rows[0]["FileSeq"] + "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string fnFileUpload(string fileConstSeq, string fileSeq, string idxNo, string upname, string file)
        {
            try
            {
                string filepath = Path.GetDirectoryName(file);
                filepath = Path.Combine(filepath, "Temp");
                if (!Directory.Exists(filepath)) Directory.CreateDirectory(filepath);
                Utils.ClearFolder(filepath);
                string tofile = Path.Combine(filepath, upname + Path.GetExtension(file));
                File.Copy(file, tofile);

                YlwSecurityJson security = YLWService.MTRServiceModule.SecurityJson.Clone();  //깊은복사
                // File Info
                FileInfo finfo = new FileInfo(tofile);
                byte[] rptbyte = (byte[])MetroSoft.HIS.cFile.ReadBinaryFile(tofile);
                string fileBase64 = Convert.ToBase64String(rptbyte);
                fileSeq = YLWService.MTRServiceModule.CallMTRFileuploadGetSeq(security, finfo, fileBase64, fileConstSeq, fileSeq, "0", idxNo);
                if (fileSeq != "") return fileSeq;
                throw new Exception("FileUpload : file_seq not returned");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool fnSaveHRTables(string fileType, string empSeq, string fileSeq, string upname)
        {
            try
            {
                YLWService.YlwSecurityJson security = YLWService.MTRServiceModule.SecurityJson.Clone();  //깊은복사
                security.serviceId = "Metro.Package.AdjHR.BisEmpAttachMng";
                security.methodId = "FileUpload";

                DataSet ds = new DataSet("ROOT");
                DataTable dt = ds.Tables.Add("DataBlock1");
                dt.Columns.Add("EmpSeq");
                dt.Columns.Add("DeptSeq");
                dt.Columns.Add("FileSelect");
                dt.Columns.Add("FileType");
                dt.Columns.Add("FileSeq");
                dt.Columns.Add("FileName");

                dt.Clear();
                DataRow dr = dt.Rows.Add();
                dr["EmpSeq"] = empSeq;
                dr["FileType"] = fileType;
                dr["FileSeq"] = fileSeq;
                dr["FileName"] = upname;

                DataSet yds = YLWService.MTRServiceModule.CallMTRServiceCallPost(security, ds);
                if (yds == null)
                {
                    return false;
                }
                foreach (DataTable dti in yds.Tables)
                {
                    if (!dti.Columns.Contains("Status")) continue;
                    if (!dti.Columns.Contains("Result")) continue;
                    if (dti.Rows.Count > 0 && Convert.ToInt32(dti.Rows[0]["Status"]) != 0)   //Status != 0 이면 저장안됨
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string fnGetFileName(string downloadFolder, string fileName)
        {
            if (!Directory.Exists(downloadFolder)) Directory.CreateDirectory(downloadFolder);
            string file = Path.Combine(downloadFolder, fileName);
            int fileCount = 0;
            while (File.Exists(file))
            {
                fileCount++;
                file = Path.GetFileNameWithoutExtension(fileName) + "(" + fileCount.ToString() + ")" + Path.GetExtension(fileName);
                file = Path.Combine(downloadFolder, file);
            }
            return file;
        }

        private bool FileMoveTo(string sourceFile, string destPath)
        {
            try
            {
                string filename = Path.GetFileName(sourceFile);
                string destFile = fnGetFileName(destPath, filename);
                File.Move(sourceFile, destFile);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
