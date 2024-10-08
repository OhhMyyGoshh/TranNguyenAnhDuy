using System;
using System.Collections.Generic;
using System.Text;

namespace TranNguyenAnhDuy
{
    public class Todo
    {
        // Các thuộc tính của lớp Todo
        public string TenViec { get; set; }
        public int DoUuTien { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }

        // Hàm khởi tạo lớp Todo
        public Todo(string tenViec, int doUuTien, string moTa, int trangThai)
        {
            TenViec = tenViec;
            DoUuTien = doUuTien;
            MoTa = moTa;
            TrangThai = trangThai;
        }

        // Hàm hiển thị thông tin công việc
        public void HienThi(int viTri)
        {
            string trangThaiText;
            switch (TrangThai)
            {
                case 0:
                    trangThaiText = "Hủy";
                    break;
                case 1:
                    trangThaiText = "Hoàn thành";
                    break;
                case 2:
                    trangThaiText = "Chờ";
                    break;
                default:
                    trangThaiText = "Không xác định";
                    break;
            }
            Console.WriteLine($"Công việc {viTri}");
            Console.WriteLine($"Tên việc: {TenViec}");
            Console.WriteLine($"Độ ưu tiên: {DoUuTien}/5");
            Console.WriteLine($"Mô tả: {MoTa}");
            Console.WriteLine($"Trạng thái: {trangThaiText}");
            Console.WriteLine();
        }
    }

    public class Program
    {
        // Hàm xóa công việc dựa trên vị trí trong danh sách
        public static void XoaViec(List<Todo> danhSachViec)
        {
            HienThiTatCaViec(danhSachViec);
            Console.WriteLine("Nhập vị trí của việc cần xóa (bắt đầu từ 1):");
            if (int.TryParse(Console.ReadLine(), out int viTri) && viTri >= 1 && viTri <= danhSachViec.Count)
            {
                danhSachViec.RemoveAt(viTri - 1);
                Console.WriteLine($"Đã xóa công việc tại vị trí {viTri}.");
            }
            else
            {
                Console.WriteLine("Vị trí không hợp lệ.");
            }
        }

        // Hàm cập nhật trạng thái công việc
        public static void CapNhatTrangThai(List<Todo> danhSachViec)
        {
            HienThiTatCaViec(danhSachViec);
            Console.WriteLine("Nhập vị trí của việc cần cập nhật trạng thái (bắt đầu từ 1):");
            if (int.TryParse(Console.ReadLine(), out int viTri) && viTri >= 1 && viTri <= danhSachViec.Count)
            {
                Console.WriteLine("Nhập trạng thái mới (0: Hủy, 1: Hoàn thành, 2: Chờ):");
                if (int.TryParse(Console.ReadLine(), out int trangThaiMoi) && trangThaiMoi >= 0 && trangThaiMoi <= 2)
                {
                    danhSachViec[viTri - 1].TrangThai = trangThaiMoi;
                    Console.WriteLine($"Đã cập nhật trạng thái cho công việc tại vị trí {viTri}.");
                }
                else
                {
                    Console.WriteLine("Trạng thái không hợp lệ.");
                }
            }
            else
            {
                Console.WriteLine("Vị trí không hợp lệ.");
            }
        }

        // Hàm tìm kiếm công việc theo tên
        public static void TimKiemTheoTen(List<Todo> danhSachViec)
        {
            Console.WriteLine("Nhập từ khóa để tìm kiếm công việc:");
            string tuKhoa = Console.ReadLine();
            bool timThay = false;

            foreach (var viec in danhSachViec)
            {
                if (viec.TenViec.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    timThay = true;
                    int viTri = danhSachViec.IndexOf(viec) + 1;
                    viec.HienThi(viTri);
                }
            }

            if (!timThay)
            {
                Console.WriteLine("Không tìm thấy công việc nào phù hợp với từ khóa.");
            }
        }

        // Hàm hiển thị công việc theo độ ưu tiên giảm dần
        public static void HienThiTheoDoUuTienGiamDan(List<Todo> danhSachViec)
        {
            danhSachViec.Sort((x, y) => y.DoUuTien.CompareTo(x.DoUuTien));
            Console.WriteLine("\nDanh sách các việc cần làm theo độ ưu tiên giảm dần:");
            int viTri = 1;

            foreach (var viec in danhSachViec)
            {
                viec.HienThi(viTri);
                viTri++;
            }
        }

        // Hàm hiển thị toàn bộ công việc
        public static void HienThiTatCaViec(List<Todo> danhSachViec)
        {
            Console.WriteLine("\nDanh sách toàn bộ các việc cần làm:");
            int viTri = 1;

            foreach (var viec in danhSachViec)
            {
                viec.HienThi(viTri);
                viTri++;
            }
        }

        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Chương trình ToDoList");
            Console.WriteLine("\n=======================================");

            List<Todo> danhSachViec = new List<Todo>
            {
                new Todo("Học lập trình", 4, "Học lập trình Python", 1),
                new Todo("Đi chơi với bạn bè", 2, "Đi uống cà phê cùng bạn bè", 2),
                new Todo("Làm bài tập C#", 3, "Hoàn thành bài tập về lớp trong C#", 2)
            };

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nChọn thao tác:");
                Console.WriteLine("1. Xóa công việc");
                Console.WriteLine("2. Cập nhật trạng thái công việc");
                Console.WriteLine("3. Tìm kiếm công việc theo tên");
                Console.WriteLine("4. Hiển thị công việc theo độ ưu tiên giảm dần");
                Console.WriteLine("5. Hiển thị toàn bộ công việc");
                Console.WriteLine("Nhấn 'q' hoặc 'Esc' để thoát.");


                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        XoaViec(danhSachViec);
                        break;
                    case ConsoleKey.D2:
                        CapNhatTrangThai(danhSachViec);
                        break;
                    case ConsoleKey.D3:
                        TimKiemTheoTen(danhSachViec);
                        break;
                    case ConsoleKey.D4:
                        HienThiTheoDoUuTienGiamDan(danhSachViec);
                        break;
                    case ConsoleKey.D5:
                        HienThiTatCaViec(danhSachViec);
                        break;
                    case ConsoleKey.Q:
                    case ConsoleKey.Escape:
                        running = false; // Thoát khỏi vòng lặp
                        break;
                    default:
                        Console.WriteLine("\nLựa chọn không hợp lệ.");
                        break;
                }

                // Ngăn cách giữa các lần lặp thao tác
                Console.WriteLine("\n---------------------------------------------");

                // Yêu cầu người dùng nhấn phím để tiếp tục
                Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Chương trình đã kết thúc.");
        }
    }
}
