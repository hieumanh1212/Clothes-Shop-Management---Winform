using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MQTE = Microsoft.Office.Interop.Excel;
namespace Xuat_Exel
{
    internal class XuatExel
    {
        // Dữ liệu từ DataGridView để chuyển sang Excel
        DataGridView dgvThongtin;

        // Tiêu đề 
        string Title;
        
        // Hang cột bắt đầu và hàng cột kết thúc
        int RowStart;
        int ClumnStart;
        int RowEnd;
        int ColumnEnd;
        int const_heght = 0;

        // check để xem muốn in Form nào 
        // 1 là hóa đơn bán
        // 2 là hóa đơn nhập
        // 3 là thống kê theo tháng
        // 4 là thống kê theo năm
        // còn lại là Quản lý nhân viên, Quản lý khách hàng, Quản lý sản phẩm
        int checkForm=0;

        // HDB
        String MaHDB, NguoiLapHD, KHmua, Voucher, TongTienHDB, PhaiTra, NgayBan;
        public void HDB(String MaHDB, String NguoiLapHD, String KHmua, String Voucher, String TongTienHDB, String PhaiTra, string NgayBan)
        {
            this.MaHDB = MaHDB;
            this.NguoiLapHD = NguoiLapHD;
            this.KHmua = KHmua;
            this.Voucher = Voucher;
            this.TongTienHDB = TongTienHDB;
            this.PhaiTra = PhaiTra;
            this.NgayBan = NgayBan;

        }
        // HDN
        String MaHDN, NhaCC, NhanVien, TongTienHDN, NgayNhap;
        public void HDN(String MaHDN, String NhaCC, String NhanVien, String TongTienHDN, string NgayNhap)
        {

            this.MaHDN = MaHDN;
            this.NhaCC = NhaCC;
            this.NhanVien = NhanVien;
            this.TongTienHDN = TongTienHDN;
            this.NgayNhap = NgayNhap;
        }

        // Doanh thu theo tháng của 1 trong 3 năm bất kì
        String HoaDonDaXuat, TongTienDaThu, TongTienDaChi, ThucTe;
        public void thang(String HoaDonDaXuat, String TongTienDaThu, String TongTienDaChi)
        {
            this.HoaDonDaXuat = HoaDonDaXuat;
            this.TongTienDaThu = TongTienDaThu;
            this.TongTienDaChi = TongTienDaChi;
            
        }








        // Đưa dữa liệu từ Form vào và khởi tạo hàng cột bắt đầu và kết thúc cho Excel
        public void NewExcel(DataGridView dgvThongtin, string Title)
        {
            this.dgvThongtin = dgvThongtin;
            this.Title = Title;
            RowStart = RowEnd = 1;
            ClumnStart = ColumnEnd = 4;
        }
        public void NewExcel(int const_heght, string Title)
        {
            this.Title = Title;
            RowStart = RowEnd = 1;
            ClumnStart = ColumnEnd = 4;
            this.const_heght = this.ColumnEnd + const_heght-1;
        }

        // Dữ liệu từ Quản lý nhân viên, Quản lý khách hàng, Quản lý sản phẩm được đưa vào trong hàm tạo này
        public XuatExel(DataGridView dgvThongtin, string Title, int checkForm)
        {
            this.checkForm = checkForm;
            NewExcel(dgvThongtin, Title);
            Xuat();

        }

        // Dữ liệu từ thống kê theo năm được đua vào trong này
        String TongThu,  TongChi;
        public void Nam(String TongThu, String TongChi)
        {

            this.TongThu = TongThu;
            this.TongChi = TongChi;

        }
        public XuatExel(DataGridView dgvThongtin, string Title, String TongThu, String TongChi)
        {
            this.checkForm = 4;
            NewExcel(dgvThongtin, Title);
            Nam(TongThu, TongChi);
            Xuat();

        }
        // Dữ liệu Hóa đơn bán được đưa vào đây
        public XuatExel(DataGridView dgvThongtin, string Title, String MaHDB, String NguoiLapHD, String KHmua, String Voucher, String TongTienHDB, String PhaiTra, String NgayBan)
        {
            NewExcel(dgvThongtin, Title);
            checkForm = 1;
            HDB(MaHDB, NguoiLapHD, KHmua, Voucher, TongTienHDB, PhaiTra, NgayBan);
            Xuat();

        }

        // Dữ liệu Hóa đơn nhập được đưa vào đây
        public XuatExel(DataGridView dgvThongtin, string Title, String MaHDN, String NhaCC, String NhanVien, String TongTienHDN, String NgayNhap)
        {
            NewExcel(dgvThongtin, Title);
            checkForm = 2;
            HDN(MaHDN, NhaCC, NhanVien, TongTienHDN, NgayNhap);
            Xuat();

        }

        // Dữ liệu thống kê theo tháng được đưa vào đây
        public XuatExel(int const_heght, string Title, String HoaDonDaXuat, String TongTienDaThu, String TongTienDaChi)
        {
            NewExcel(const_heght, Title);
            checkForm = 3;
            thang(HoaDonDaXuat, TongTienDaThu, TongTienDaChi);
            Xuat();

        }


        public void Excel(string Path)
        {
            //MQTE: Microsoft.Office.Interop.Excel
            //Khai báo các đối tượng Excel
            MQTE.Application oExcel = new MQTE.Application();
            MQTE.Workbooks oBooks;
            MQTE.Sheets oSheets;
            MQTE.Workbook oBook;
            MQTE.Worksheet oSheet;

            // Tạo mới một Excel 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            //oExcel.Columns.AutoFit();

            oBooks = oExcel.Workbooks;
            oBook = (MQTE.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;
            oSheet = (MQTE.Worksheet)oSheets.Add(Type.Missing);// Chú ý trong Add là 1 nhưng mà đang thử là Type.Missing
                                                               //oSheet.Name = SheetName;


            // Nhóm N12
            MQTE.Range Nhom = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 2, this.ClumnStart],
                                       (MQTE.Range)oSheet.Cells[this.RowEnd + 2, this.ColumnEnd + 2]];
            Nhom.MergeCells = true;
            Nhom.Value2 = "HTT N12 GROUP";
            Nhom.Font.Size = "20";
            Nhom.HorizontalAlignment = MQTE.XlHAlign.xlHAlignCenter;
            Nhom.Font.Bold = true;

            // Dịa chỉ
            MQTE.Range DiaChi = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 3, this.ClumnStart],
                                       (MQTE.Range)oSheet.Cells[this.RowEnd + 3, this.ColumnEnd + 2]];
            DiaChi.MergeCells = true;
            DiaChi.Value2 = "Địa chỉ: Số 3, Cầu Giấy, Hà Nội";
            DiaChi.Font.Size = "15";
            DiaChi.HorizontalAlignment = MQTE.XlHAlign.xlHAlignCenter;
            DiaChi.Font.Bold = true;

            // Liên hệ
            MQTE.Range LienHe = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 4, this.ClumnStart],
                                       (MQTE.Range)oSheet.Cells[this.RowEnd + 4, this.ColumnEnd + 2]];
            LienHe.MergeCells = true;
            LienHe.Value2 = "Liên hệ: 0123456789 - 0987654321";
            LienHe.Font.Size = "15";
            LienHe.HorizontalAlignment = MQTE.XlHAlign.xlHAlignCenter;
            LienHe.Font.Bold = true;

            // Email
            MQTE.Range Email = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 5, this.ClumnStart],
                                       (MQTE.Range)oSheet.Cells[this.RowEnd + 5, this.ColumnEnd + 2]];
            Email.MergeCells = true;
            Email.Value2 = "Email: N12@gmail.com";
            Email.Font.Size = "15";
            Email.HorizontalAlignment = MQTE.XlHAlign.xlHAlignCenter;
            Email.Font.Bold = true;

            // Website
            MQTE.Range Website = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart +6, this.ClumnStart],
                                       (MQTE.Range)oSheet.Cells[this.RowEnd + 6, this.ColumnEnd + 2]];
            Website.MergeCells = true;
            Website.Value2 = "WebSite: WWW.HTTGROUP.VN";
            Website.Font.Size = "15";
            Website.HorizontalAlignment = MQTE.XlHAlign.xlHAlignCenter;
            Website.Font.Bold = true;


            
            if(checkForm != 3)
                const_heght = this.ColumnEnd + dgvThongtin.ColumnCount - 1;
            

            // Tên của hàng
            MQTE.Range TenCuaHang = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart+9, this.ClumnStart],
                                       (MQTE.Range)oSheet.Cells[this.RowEnd + 9, const_heght]];

            // Gộp thành 1 ô
            TenCuaHang.MergeCells = true;

            // Giá trị tại athor
            TenCuaHang.Value2 = "CỬA HÀNG BÁN QUẦN ÁO N12";
            TenCuaHang.Font.Size = "25";
            TenCuaHang.Font.Bold = true;
            TenCuaHang.Font.Color = Color.Red;
            TenCuaHang.HorizontalAlignment = MQTE.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề 
            // Gộp ô theo RowStart, ClumnStart và ColumnEnd chỉnh font và cỡ chữ
            MQTE.Range head = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 14, this.ClumnStart],
            (MQTE.Range)oSheet.Cells[this.RowStart + 14, const_heght]];
            head.MergeCells = true;
            head.Value2 = Title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = MQTE.XlHAlign.xlHAlignCenter;


            if (checkForm != 3)
            {
                // thiết lập thêm vùng hiển thị cho hóa đơn bán và hóa đơn nhập
                if (checkForm == 1 || checkForm == 2)
                {
                    //Vung hiển thị dữ liệu mã hóa đơn
                    MQTE.Range MaHDB = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 10, this.ClumnStart],
                    (MQTE.Range)oSheet.Cells[this.RowStart + 10, this.ColumnEnd + 3]];
                    MaHDB.Value2 = checkForm == 1 ? "Mã hóa đơn:      " + this.MaHDB : "Mã hóa đơn:      " + this.MaHDN;
                    MaHDB.MergeCells = true;
                    MaHDB.Font.Bold = true;

                    // Vung hiển thị dữ liệu người lập hóa đơn || nhà cung cấp
                    MQTE.Range NguoiLapHD = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 11, this.ClumnStart],
                    (MQTE.Range)oSheet.Cells[this.RowStart + 11, this.ColumnEnd + 3]];
                    NguoiLapHD.Value2 = checkForm == 1 ? "Người lập hóa đơn:     " + this.NguoiLapHD : "Nhà cung cấp:     " + this.NhaCC;
                    NguoiLapHD.MergeCells = true;
                    NguoiLapHD.Font.Bold = true;

                    // Vung hiển thị dữ liệu Khách hàng mua || nhân viên
                    MQTE.Range KHmua = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 12, this.ClumnStart],
                    (MQTE.Range)oSheet.Cells[this.RowStart + 12, this.ColumnEnd + 3]];
                    KHmua.Value2 = checkForm == 1 ? "Khách hàng:     " + this.KHmua : "Nhân viên:     " + this.NhanVien;
                    KHmua.MergeCells = true;
                    KHmua.Font.Bold = true;

                    // Vung hiển thị dữ liệu Khách ngày bán || ngày nhập
                    MQTE.Range Ngay = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 13, this.ClumnStart],
                    (MQTE.Range)oSheet.Cells[this.RowStart + 13, this.ColumnEnd + 3]];
                    Ngay.Value2 = checkForm == 1 ? "Ngày bán:     " + this.NgayBan : "Ngày nhập:     " + this.NgayNhap;
                    Ngay.MergeCells = true;
                    Ngay.Font.Bold = true;
                    if (checkForm == 1)
                    {
                        // Vung hiển thị dữ liệu tổng tiền
                        oSheet.Cells[this.RowStart + 18 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 2] = "Tổng Tiền: ";
                        oSheet.Cells[this.RowStart + 18 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 2].Font.Bold = true;

                        oSheet.Cells[this.RowStart + 18 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 1] = this.TongTienHDB;
                        oSheet.Cells[this.RowStart + 18 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 1].Font.Bold = true;

                        //Vung hiển thị dữ liệu Voucher
                        oSheet.Cells[this.RowStart + 19 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 2] = "Voucher: ";
                        oSheet.Cells[this.RowStart + 19 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 2].Font.Bold = true;

                        oSheet.Cells[this.RowStart + 19 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 1] = this.Voucher;
                        oSheet.Cells[this.RowStart + 19 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 1].Font.Bold = true;

                        // Vung hiển thị dữ liệu PhaiTra
                        oSheet.Cells[this.RowStart + 20 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 2] = "Thành tiền: ";
                        oSheet.Cells[this.RowStart + 20 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 2].Font.Bold = true;

                        oSheet.Cells[this.RowStart + 20 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 1] = this.PhaiTra;
                        oSheet.Cells[this.RowStart + 20 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 1].Font.Bold = true;
                    }
                    if (checkForm == 2)
                    {
                        // Vung hiển thị dữ liệu tổng tiền
                        oSheet.Cells[this.RowStart + 18 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 2] = "Tổng Tiền: ";
                        oSheet.Cells[this.RowStart + 18 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 2].Font.Bold = true;

                        oSheet.Cells[this.RowStart + 18 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 1] = this.TongTienHDN;
                        oSheet.Cells[this.RowStart + 18 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 1].Font.Bold = true;
                    }
                }


                




                // tạo header Text
                object[] dataHeader = new object[dgvThongtin.ColumnCount];
                for (int c = 0; c < dgvThongtin.ColumnCount; c++)
                    dataHeader[c] = dgvThongtin.Columns[c].HeaderText;

                /*
                  - ô bắt đầu điền header Text: (MQTE.Range)oSheet.Cells[this.RowStart+16, this.ClumnStart];
                  - ô kết thúc điền header Text: (MQTE.Range)oSheet.Cells[this.RowEnd + 16, this.ColumnEnd + dgvThongtin.ColumnCount - 1]]
                */
                // lấy về vùng điền header Text
                MQTE.Range RangeHeader = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 16, this.ClumnStart],
                (MQTE.Range)oSheet.Cells[this.RowEnd + 16, this.ColumnEnd + dgvThongtin.ColumnCount - 1]];

                // điền header Text vào vùng đã thiệt lập
                RangeHeader.Value2 = dataHeader;

                // Chỉnh in đậm chữ cho header Text
                RangeHeader.Font.Bold = true;

                // Kẻ viền header Text
                RangeHeader.Borders.LineStyle = MQTE.Constants.xlSolid;

                // Thiết lập mầu nền header Text
                RangeHeader.Interior.Color = Color.Yellow;

                // căn header Text ra giữa 
                RangeHeader.HorizontalAlignment = MQTE.XlHAlign.xlHAlignCenter;

                // căn độ rộng cột của header Text
                RangeHeader.ColumnWidth = 22;


                /*
                  - ô bắt đầu điền dữ liệu: (MQTE.Range)oSheet.Cells[this.RowStart + 17, this.ClumnStart];
                  - ô kết thúc điền dữ liệu: (MQTE.Range)oSheet.Cells[this.RowEnd + 17 + dgvThongtin.RowCount - 2, this.ColumnEnd  + dgvThongtin.ColumnCount - 1]]
                */

                // lấy về vùng điền dữ liệu
                int dong = 1;
                if (checkForm == 4)
                {
                    dong = 2;
                    // Vung hiển thị dữ liệu tổng thu
                    oSheet.Cells[this.RowStart + 17 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 2] = "Tổng thu: ";
                    oSheet.Cells[this.RowStart + 17 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 2].Font.Bold = true;

                    oSheet.Cells[this.RowStart + 17 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 1] = this.TongThu;
                    oSheet.Cells[this.RowStart + 17 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 1].Font.Bold = true;

                    //Vung hiển thị dữ liệu tổng chi
                    oSheet.Cells[this.RowStart + 18 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 2] = "Tổng chi: ";
                    oSheet.Cells[this.RowStart + 18 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 2].Font.Bold = true;

                    oSheet.Cells[this.RowStart + 18 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 1] = this.TongChi;
                    oSheet.Cells[this.RowStart + 18 + dgvThongtin.RowCount, this.ClumnStart + dgvThongtin.ColumnCount - 1].Font.Bold = true;

                }    
                    
                MQTE.Range range = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 17, this.ClumnStart],
                (MQTE.Range)oSheet.Cells[this.RowEnd + 17 + dgvThongtin.RowCount - dong, this.ColumnEnd + dgvThongtin.ColumnCount - 1]];

                // kẻ viền
                range.Borders.LineStyle = MQTE.Constants.xlSolid;

                // căn giữ dữ liệu 
                range.HorizontalAlignment = MQTE.XlHAlign.xlHAlignCenter;

                // chuyền dữ liệu từ dgbthongtin vào  excel
                for (int r = 0; r < dgvThongtin.RowCount; r++)
                {
                    for (int c = 0; c < dgvThongtin.ColumnCount; c++)
                        if(dgvThongtin.Rows[r].Cells[c].Value!=null)
                            oSheet.Cells[this.RowStart + 17 + r, this.ClumnStart + c] = dgvThongtin.Rows[r].Cells[c].Value.ToString();
                }

                

                // Dữ nguyên số 0 cho số  điện thoại
                //range.Columns.NumberFormat = "0#";
            }
            else
            {
                MQTE.Range RangeHeader = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 16, this.ClumnStart],
                (MQTE.Range)oSheet.Cells[this.RowEnd + 17, const_heght]];

                MQTE.Range data = oSheet.Range[(MQTE.Range)oSheet.Cells[this.RowStart + 17, this.ClumnStart],
                (MQTE.Range)oSheet.Cells[this.RowEnd + 17, const_heght]];

                oSheet.Cells[this.RowStart + 16, this.ColumnEnd] =  "Hóa đơn đã xuất";
                oSheet.Cells[this.RowStart + 17, this.ColumnEnd] =  this.HoaDonDaXuat;

                oSheet.Cells[this.RowStart + 16, this.ColumnEnd+1] =  "Tổng tiền đã thu";
                oSheet.Cells[this.RowStart + 17, this.ColumnEnd+1] =  this.TongTienDaThu;

                oSheet.Cells[this.RowStart + 16, this.ColumnEnd+2] =  "Tổng tiền đã chi";
                oSheet.Cells[this.RowStart + 17, this.ColumnEnd+2] =  this.TongTienDaChi;



                // Chỉnh in đậm chữ cho header Text
                RangeHeader.Font.Bold = true;

                // Kẻ viền header Text
                RangeHeader.Borders.LineStyle = MQTE.Constants.xlSolid;

                // Thiết lập mầu nền header Text
                RangeHeader.Interior.Color = Color.Yellow;
                data.Interior.Color = Color.White;
                // căn header Text ra giữa 
                RangeHeader.HorizontalAlignment = MQTE.XlHAlign.xlHAlignCenter;

                // căn độ rộng cột của header Text
                RangeHeader.ColumnWidth = 22;   
                
            }


            //Lưu file excel
            //try
            //{
            //    oExcel.ActiveWorkbook.SaveCopyAs(Path);
            //    oExcel.ActiveWorkbook.Saved = true;
            //}
            //catch { }

        }

        public void Xuat()
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Title = "Export Excel";
            //saveFileDialog.Filter = "Exel 97-2002 Workbook|*.xls|Excel Workbook|*.xlsx|All Files|*.*";
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        Excel(saveFileDialog.FileName);
            //    }
            //    catch
            //    {
            //        MessageBox.Show("In không thành công");
            //    }

            //}
            Excel("");
        }


    }
}

