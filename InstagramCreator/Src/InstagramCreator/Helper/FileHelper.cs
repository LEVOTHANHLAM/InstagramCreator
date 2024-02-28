using Serilog;

namespace InstagramCreator.Helper
{
    public class FileHelper
    {
        public void CopyImagesToFolder(string sourceFolderPath, string destinationFolderPath)
        {
            if (!Directory.Exists(sourceFolderPath))
            {
                Console.WriteLine("Thư mục nguồn không tồn tại.");
                Log.Error("Thư mục nguồn không tồn tại. \n" + sourceFolderPath);
                return;
            }

            if (!Directory.Exists(destinationFolderPath))
            {
                Directory.CreateDirectory(destinationFolderPath);
            }

            string[] imageFiles = Directory.GetFiles(sourceFolderPath)
                .Where(file => IsImageFile(file))
                .ToArray();

            foreach (string imagePath in imageFiles)
            {
                string fileName = Path.GetFileName(imagePath);
                string destinationPath = Path.Combine(destinationFolderPath, fileName);
                File.Copy(imagePath, destinationPath, true);
            }

            Console.WriteLine($"Đã sao chép {imageFiles.Length} tệp tin hình ảnh thành công.");
        }

        public bool IsImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);

            if (extension != null && (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                      extension.Equals(".png", StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }

            return false;
        }
        public string GetRandomFileLink(string folderPath)
        {
            Random random = new Random();
            string[] files = Directory.GetFiles(folderPath);

            if (files.Length == 0)
            {
                Log.Error("The specified folder does not contain any files.");
                return null;
            }

            string randomFile = files[random.Next(files.Length)];
            string fileLink = Path.GetFullPath(randomFile);

            return fileLink;
        }
        public static string RandomStringWithExtraChars(List<string> stringList)
        {
            Random random = new Random();
            string selectedString = stringList[random.Next(stringList.Count)];
            return selectedString;
        }
        public static List<string> ReadImageFiles(string folderPath)
        {
            List<string> files = new List<string>();
            if (Directory.Exists(folderPath))
            {
                string[] imageExtensions = { ".jpg", ".png" };

                // Lấy tất cả các tệp hình ảnh trong thư mục và các thư mục con.
                string[] imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                    .Where(file => imageExtensions.Contains(Path.GetExtension(file).ToLower()))
                    .ToArray();

                // In danh sách các tệp hình ảnh.
                foreach (string imageFile in imageFiles)
                {
                    files.Add(imageFile);
                }
            }
            else
            {
                MessageCommon.ShowMessageBox("Directory does not exist.", 4);
            }
            return files;
        }
        public static string TakeRandomList(List<string> headers)
        {
            try
            {
                Random random = new Random();
                var result = headers[random.Next(headers.Count)];
                return result;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            return null;
        }
        public static List<string> ReadFile(string path)
        {
            var list = new List<string>();
            try
            {
                var result = File.ReadAllLines(path);
                Log.Information("ReadFile " + path);
                for (int i = 0; i < result.Length; i++)
                {
                    string[] lines = result[i].Split(':', ';', ',', '|');
                    if (!string.IsNullOrEmpty(lines[0]))
                    {
                        list.Add(lines[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
            return list;
        }
        public static List<string> LastnamesVN = new List<string>
            {
                    "Phương Chi","An Bình","An Di","An Hạ","An Hằng","An Khê","An Nhiên","An Nhàn","Anh Chi","Anh Hương","Anh Mai",
"Anh Phương","Anh Thi","Anh Thy","Anh Thơ","Anh Thư","Anh Thảo","Anh Vũ","Anh Ðào","Ban Mai","Bình Minh","Bình Yên",
"Bích Chiêu","Bích Châu","Bích Duyên","Bích Hiền","Bích Huệ","Bích Hà","Bích Hạnh","Bích Hải","Bích Hảo","Bích Hậu","Bích Hằng","Bích Hồng","Bích Hợp","Bích Lam","Bích Liên","Bích Loan","Bích Nga",
"Bích Ngà","Bích Ngân","Bích Ngọc","Bích Như","Bích Phượng","Bích Quyên","Bích Quân","Bích San","Bích Thoa","Bích Thu","Bích Thảo","Bích Thủy","Bích Trang","Bích Trâm","Bích Ty","Bích Vân","Bích Ðiệp",
"Bích Ðào","Băng Băng","Băng Tâm","Bạch Cúc","Bạch Hoa","Bạch Kim","Bạch Liên","Bạch Loan","Bạch Mai","Bạch Quỳnh","Bạch Trà","Bạch Tuyết","Bạch Vân","Bạch Yến","Bảo Anh","Bảo Bình","Bảo Châu","Bảo Huệ",
"Bảo Hà","Bảo Hân","Bảo Lan","Bảo Lễ","Bảo Ngọc","Bảo Phương","Bảo Quyên","Bảo Quỳnh","Bảo Thoa","Bảo Thúy","Bảo Tiên","Bảo Trâm","Bảo Trân","Bảo Trúc","Bảo Uyên","Bảo Vy","Bảo Vân","Bội Linh","Cam Thảo"
,"Chi Lan","Chi Mai","Chiêu Dương","Cát Cát","Cát Linh","Cát Ly","Cát Tiên","Cát Tường","Cẩm Hiền","Cẩm Hường","Cẩm Hạnh","Cẩm Linh","Cẩm Liên","Cẩm Ly","Cẩm Nhi","Cẩm Nhung","Cẩm Thúy","Cẩm Tú",
"Cẩm Vân","Cẩm Yến","Di Nhiên","Diên Vỹ","Diễm Chi","Diễm Châu","Diễm Hương","Diễm Hạnh","Diễm Hằng","Diễm Khuê","Diễm Kiều","Diễm Liên","Diễm Lộc","Diễm My","Diễm Phúc","Diễm Phương","Diễm Phước",
"Diễm Phượng","Diễm Quyên","Diễm Quỳnh","Diễm Thúy","Diễm Thư","Diễm Thảo","Diễm Trang","Diễm Trinh","Diễm Uyên","Diệp Anh","Diệp Vy","Diệu Anh","Diệu Hiền","Diệu Hoa","Diệu Huyền","Diệu Hương",
"Diệu Hạnh","Diệu Hằng","Diệu Hồng","Diệu Lan","Diệu Linh","Diệu Loan","Diệu Nga","Diệu Ngà","Diệu Ngọc","Diệu Nương","Diệu Thiện","Diệu Thúy","Diệu Vân","Diệu Ái","Duy Hạnh","Duy Mỹ","Duy Uyên",
"Duyên Hồng","Duyên My","Duyên Mỹ","Duyên Nương","Dã Lan","Dã Lâm","Dã Thảo","Dạ Hương","Dạ Lan","Dạ Nguyệt","Dạ Thi","Dạ Thảo","Dạ Yến","Gia Hân","Gia Khanh","Gia Linh","Gia Nhi","Gia Quỳnh",
"Giang Thanh","Giang Thiên","Giao Hưởng","Giao Kiều","Giao Linh","Giáng Ngọc","Giáng Tiên","Giáng Uyên","Hiếu Giang","Hiếu Hạnh","Hiếu Khanh","Hiếu Minh","Hiền Chung","Hiền Hòa","Hiền Mai","Hiền Nhi",
"Hiền Nương","Hiền Thục","Hiểu Lam","Hiểu Vân","Hoa Liên","Hoa Lý","Hoa Thiên","Hoa Tiên","Hoa Tranh","Hoài An","Hoài Giang","Hoài Hương","Hoài Phương","Hoài Thương","Hoài Trang","Hoài Vỹ","Hoàn Châu",
"Hoàn Vi","Hoàng Cúc","Hoàng Hà","Hoàng Kim","Hoàng Lan","Hoàng Mai","Hoàng Miên","Hoàng Nguyên","Hoàng Oanh","Hoàng Sa","Hoàng Thư","Hoàng Xuân","Hoàng Yến","Hoạ Mi","Huyền Anh","Huyền Diệu",
"Huyền Linh","Huyền Ngọc","Huyền Nhi","Huyền Thoại","Huyền Thư","Huyền Trang","Huyền Trâm","Huyền Trân","Huệ An","Huệ Hương","Huệ Hồng","Huệ Lan","Huệ Linh","Huệ Lâm","Huệ My","Huệ Phương",
"Huệ Thương","Huệ Ân","Huỳnh Anh","Hà Giang","Hà Liên","Hà Mi","Hà My","Hà Nhi","Hà Phương","Hà Thanh","Hà Tiên","Hàm Duyên","Hàm Nghi","Hàm Thơ","Hàm Ý","Hương Chi","Hương Giang","Hương Lan",
"Hương Liên","Hương Ly","Hương Lâm","Hương Mai","Hương Nhi","Hương Thu","Hương Thảo","Hương Thủy","Hương Tiên","Hương Trang","Hương Trà","Hương Xuân","Hướng Dương","Hạ Băng","Hạ Giang","Hạ Phương",
"Hạ Tiên","Hạ Uyên","Hạ Vy","Hạc Cúc","Hạnh Chi","Hạnh Dung","Hạnh Linh","Hạnh My","Hạnh Nga","Hạnh Nhơn","Hạnh Phương","Hạnh San","Hạnh Thảo","Hạnh Trang","Hạnh Vi","Hải Anh","Hải Châu","Hải Duyên",
"Hải Dương","Hải Miên","Hải My","Hải Mỹ","Hải Ngân","Hải Nhi","Hải Phương","Hải Phượng","Hải San","Hải Sinh","Hải Thanh","Hải Thảo","Hải Thụy","Hải Uyên","Hải Vy","Hải Vân","Hải Yến","Hải Ân","Hải Ðường"
,"Hảo Nhi","Hằng Anh","Hằng Nga","Họa Mi","Hồ Diệp","Hồng Anh","Hồng Bạch Thảo","Hồng Châu","Hồng Diễm","Hồng Giang","Hồng Hoa","Hồng Hà","Hồng Hạnh","Hồng Khanh","Hồng Khuê","Hồng Khôi","Hồng Linh",
"Hồng Liên","Hồng Lâm","Hồng Mai","Hồng Nga","Hồng Ngân","Hồng Ngọc","Hồng Nhung","Hồng Như","Hồng Nhạn","Hồng Oanh","Hồng Phúc","Hồng Phương","Hồng Quế","Hồng Thu","Hồng Thúy","Hồng Thư","Hồng Thảo",
"Hồng Thắm","Hồng Thủy","Hồng Trúc","Hồng Tâm","Hồng Vân","Hồng Xuân","Hồng Ðiệp","Hồng Ðào","Hồng Đăng","Khiết Linh","Khiết Tâm","Khuê Trung","Khánh Chi","Khánh Giang","Khánh Giao","Khánh Huyền",
"Khánh Hà","Khánh Hằng","Khánh Linh","Khánh Ly","Khánh Mai","Khánh My","Khánh Ngân","Khánh Ngọc","Khánh Quyên","Khánh Quỳnh","Khánh Thủy","Khánh Trang","Khánh Vi","Khánh Vy","Khánh Vân","Khúc Lan",
"Khả Khanh","Khả Tú","Khả Ái","Khải Ca","Khải Hà","Khải Tâm","Kim Anh","Kim Chi","Kim Cương","Kim Dung","Kim Duyên","Kim Hoa","Kim Hương","Kim Khanh","Kim Khuyên","Kim Khánh","Kim Lan","Kim Liên",
"Kim Loan","Kim Ly","Kim Mai","Kim Ngân","Kim Ngọc","Kim Oanh","Kim Phượng","Kim Quyên","Kim Sa","Kim Thanh","Kim Thoa","Kim Thu","Kim Thy","Kim Thông","Kim Thư","Kim Thảo","Kim Thủy","Kim Trang",
"Kim Tuyến","Kim Tuyết","Kim Tuyền","Kim Xuyến","Kim Xuân","Kim Yến","Kim Ánh","Kim Đan","Kiết Hồng","Kiết Trinh","Kiều Anh","Kiều Diễm","Kiều Dung","Kiều Giang","Kiều Hoa","Kiều Hạnh","Kiều Khanh",
"Kiều Loan","Kiều Mai","Kiều Minh","Kiều Mỹ","Kiều Nga","Kiều Nguyệt","Kiều Nương","Kiều Thu","Kiều Trang","Kiều Trinh","Kỳ Anh","Kỳ Diệu","Kỳ Duyên","Lam Giang","Lam Hà","Lam Khê","Lam Ngọc",
"Lam Tuyền","Lan Anh","Lan Chi","Lan Hương","Lan Khuê","Lan Ngọc","Lan Nhi","Lan Phương","Lan Thương","Lan Trúc","Lan Vy","Linh Chi","Linh Châu","Linh Duyên","Linh Giang","Linh Hà","Linh Lan",
"Linh Nhi","Linh Phương","Linh Phượng","Linh San","Linh Trang","Linh Ðan","Liên Chi","Liên Hoa","Liên Hương","Liên Như","Liên Phương","Liên Trân","Liễu Oanh","Loan Châu","Ly Châu","Lâm Nhi","Lâm Oanh",
"Lâm Tuyền","Lâm Uyên","Lê Quỳnh","Lưu Ly","Lệ Băng","Lệ Chi","Lệ Giang","Lệ Hoa","Lệ Huyền","Lệ Khanh","Lệ Nga","Lệ Nhi","Lệ Quyên","Lệ Quân","Lệ Thanh","Lệ Thu","Lệ Thủy","Lộc Uyên","Lộc Uyển",
"Lục Bình","Mai Anh","Mai Chi","Mai Châu","Mai Hiền","Mai Hà","Mai Hương","Mai Hạ","Mai Khanh","Mai Khôi","Mai Lan","Mai Linh","Mai Liên","Mai Loan","Mai Ly","Mai Nhi","Mai Phương","Mai Quyên",
"Mai Thanh","Mai Thu","Mai Thy","Mai Thảo","Mai Trinh","Mai Tâm","Mai Vy","Minh An","Minh Châu","Minh Duyên","Minh Hiền","Minh Huyền","Minh Huệ","Minh Hà","Minh Hương","Minh Hạnh","Minh Hằng",
"Minh Hồng","Minh Khai","Minh Khuê","Minh Loan","Minh Minh","Minh Nguyệt","Minh Ngọc","Minh Nhi","Minh Như","Minh Phương","Minh Phượng","Minh Thu","Minh Thúy","Minh Thư","Minh Thương","Minh Thảo",
"Minh Thủy","Minh Trang","Minh Tuyết","Minh Tuệ","Minh Tâm","Minh Uyên","Minh Vy","Minh Xuân","Minh Yến","Minh Đan","Mậu Xuân","Mộc Miên","Mộng Hoa","Mộng Hương","Mộng Hằng","Mộng Lan","Mộng Liễu",
"Mộng Nguyệt","Mộng Nhi","Mộng Quỳnh","Mộng Thi","Mộng Thu","Mộng Tuyền","Mộng Vi","Mộng Vy","Mộng Vân","Mộng Ðiệp","Mỹ Anh","Mỹ Diễm","Mỹ Dung","Mỹ Duyên","Mỹ Hiệp","Mỹ Hoàn","Mỹ Huyền","Mỹ Huệ",
"Mỹ Hường","Mỹ Hạnh","Mỹ Khuyên","Mỹ Kiều","Mỹ Lan","Mỹ Loan","Mỹ Lệ","Mỹ Lợi","Mỹ Nga","Mỹ Ngọc","Mỹ Nhi","Mỹ Nhân","Mỹ Nương","Mỹ Phương","Mỹ Phượng","Mỹ Phụng","Mỹ Thuần","Mỹ Thuận","Mỹ Trang",
"Mỹ Trâm","Mỹ Tâm","Mỹ Uyên","Mỹ Vân","Mỹ Xuân","Mỹ Yến","Nghi Dung","Nghi Minh","Nghi Xuân","Nguyên Hồng","Nguyên Thảo","Nguyết Ánh","Nguyệt Anh","Nguyệt Cát","Nguyệt Cầm","Nguyệt Hà","Nguyệt Hồng"
,"Nguyệt Lan","Nguyệt Minh","Nguyệt Nga","Nguyệt Quế","Nguyệt Uyển","Nguyệt Ánh","Ngân Anh","Ngân Hà","Ngân Thanh","Ngân Trúc","Ngọc Anh","Ngọc Bích","Ngọc Cầm","Ngọc Diệp","Ngọc Dung","Ngọc Hiền",
"Ngọc Hoa","Ngọc Hoan","Ngọc Hoàn","Ngọc Huyền","Ngọc Huệ","Ngọc Hà","Ngọc Hân","Ngọc Hạ","Ngọc Hạnh","Ngọc Hằng","Ngọc Khanh","Ngọc Khuê","Ngọc Khánh","Ngọc Lam","Ngọc Lan","Ngọc Linh","Ngọc Liên",
"Ngọc Loan","Ngọc Ly","Ngọc Lâm","Ngọc Lý","Ngọc Lệ","Ngọc Mai","Ngọc Nhi","Ngọc Nữ","Ngọc Oanh","Ngọc Phụng","Ngọc Quyên","Ngọc Quế","Ngọc Quỳnh","Ngọc San","Ngọc Sương","Ngọc Thi","Ngọc Thy",
"Ngọc Thơ","Ngọc Trinh","Ngọc Trâm","Ngọc Tuyết","Ngọc Tâm","Ngọc Tú","Ngọc Uyên","Ngọc Uyển","Ngọc Vy","Ngọc Vân","Ngọc Yến","Ngọc Ái","Ngọc Ánh","Ngọc Ðiệp","Ngọc Ðàn","Ngọc Ðào","Nhan Hồng",
"Nhã Hương","Nhã Hồng","Nhã Khanh","Nhã Lý","Nhã Mai","Nhã Sương","Nhã Thanh","Nhã Trang","Nhã Trúc","Nhã Uyên","Nhã Yến","Nhã Ý","Như Anh","Như Bảo","Như Hoa","Như Hảo","Như Hồng","Như Loan",
"Như Mai","Như Ngà","Như Ngọc","Như Phương","Như Quân","Như Quỳnh","Như Thảo","Như Trân","Như Tâm","Như Ý","Nhất Thương","Nhật Dạ","Nhật Hà","Nhật Hạ","Nhật Lan","Nhật Linh","Nhật Lệ","Nhật Mai",
"Nhật Phương","Nhật Ánh","Oanh Thơ","Oanh Vũ","Phi Khanh","Phi Nhung","Phi Nhạn","Phi Phi","Phi Phượng","Phong Lan","Phương An","Phương Anh","Phương Chi","Phương Châu","Phương Diễm","Phương Dung",
"Phương Giang","Phương Hiền","Phương Hoa","Phương Hạnh","Phương Lan","Phương Linh","Phương Liên","Phương Loan","Phương Mai","Phương Nghi","Phương Ngọc","Phương Nhi","Phương Nhung","Phương Phương",
"Phương Quyên","Phương Quân","Phương Quế","Phương Quỳnh","Phương Thanh","Phương Thi","Phương Thùy","Phương Thảo","Phương Thủy","Phương Trang","Phương Trinh","Phương Trà","Phương Trâm","Phương Tâm",
"Phương Uyên","Phương Yến","Phước Bình","Phước Huệ","Phượng Bích","Phượng Liên","Phượng Loan","Phượng Lệ","Phượng Nga","Phượng Nhi","Phượng Tiên","Phượng Uyên","Phượng Vy","Phượng Vũ","Phụng Yến",
"Quế Anh","Quế Chi","Quế Linh","Quế Lâm","Quế Phương","Quế Thu","Quỳnh Anh","Quỳnh Chi","Quỳnh Dao","Quỳnh Dung","Quỳnh Giang","Quỳnh Giao","Quỳnh Hoa","Quỳnh Hà","Quỳnh Hương","Quỳnh Lam",
"Quỳnh Liên","Quỳnh Lâm","Quỳnh Nga","Quỳnh Ngân","Quỳnh Nhi","Quỳnh Nhung","Quỳnh Như","Quỳnh Phương","Quỳnh Sa","Quỳnh Thanh","Quỳnh Thơ","Quỳnh Tiên","Quỳnh Trang","Quỳnh Trâm","Quỳnh Vân",
"Sao Băng","Sao Mai","Song Kê","Song Lam","Song Oanh","Song Thư","Sông Hà","Sông Hương","Sơn Ca","Sơn Tuyền","Sương Sương","Thanh Bình","Thanh Dân","Thanh Giang","Thanh Hiếu","Thanh Hiền",
"Thanh Hoa","Thanh Huyền","Thanh Hà","Thanh Hương","Thanh Hường","Thanh Hạnh","Thanh Hảo","Thanh Hằng","Thanh Hồng","Thanh Kiều","Thanh Lam","Thanh Lan","Thanh Loan","Thanh Lâm","Thanh Mai",
"Thanh Mẫn","Thanh Nga","Thanh Nguyên","Thanh Ngân","Thanh Ngọc","Thanh Nhung","Thanh Nhàn","Thanh Nhã","Thanh Phương","Thanh Thanh","Thanh Thiên","Thanh Thu","Thanh Thúy","Thanh Thư","Thanh Thảo",
"Thanh Thủy","Thanh Trang","Thanh Trúc","Thanh Tuyết","Thanh Tuyền","Thanh Tâm","Thanh Uyên","Thanh Vy","Thanh Vân","Thanh Xuân","Thanh Yến","Thanh Đan","Thi Cầm","Thi Ngôn","Thi Thi","Thi Xuân",
"Thi Yến","Thiên Di","Thiên Duyên","Thiên Giang","Thiên Hà","Thiên Hương","Thiên Khánh","Thiên Kim","Thiên Lam","Thiên Lan","Thiên Mai","Thiên Mỹ","Thiên Nga","Thiên Nương","Thiên Phương",
"Thiên Thanh","Thiên Thêu","Thiên Thư","Thiên Thảo","Thiên Trang","Thiên Tuyền","Thiếu Mai","Thiều Ly","Thiện Mỹ","Thiện Tiên","Thu Duyên","Thu Giang","Thu Hiền","Thu Hoài","Thu Huyền","Thu Huệ",
"Thu Hà","Thu Hậu","Thu Hằng","Thu Hồng","Thu Linh","Thu Liên","Thu Loan","Thu Mai","Thu Minh","Thu Nga","Thu Nguyệt","Thu Ngà","Thu Ngân","Thu Ngọc","Thu Nhiên","Thu Oanh","Thu Phong","Thu Phương",
"Thu Phượng","Thu Sương","Thu Thuận","Thu Thảo","Thu Thủy","Thu Trang","Thu Việt","Thu Vân","Thu Vọng","Thu Yến","Thuần Hậu","Thy Khanh","Thy Oanh","Thy Trúc","Thy Vân","Thái Chi","Thái Hà",
"Thái Hồng","Thái Lan","Thái Lâm","Thái Thanh","Thái Thảo","Thái Tâm","Thái Vân","Thùy Anh","Thùy Dung","Thùy Dương","Thùy Giang","Thùy Linh","Thùy Mi","Thùy My","Thùy Nhi","Thùy Như","Thùy Oanh",
"Thùy Uyên","Thùy Vân","Thúy Anh","Thúy Diễm","Thúy Hiền","Thúy Huyền","Thúy Hà","Thúy Hương","Thúy Hường","Thúy Hạnh","Thúy Hằng","Thúy Kiều","Thúy Liên","Thúy Liễu","Thúy Loan","Thúy Mai",
"Thúy Minh","Thúy My","Thúy Nga","Thúy Ngà","Thúy Ngân","Thúy Ngọc","Thúy Phượng","Thúy Quỳnh","Thúy Vi","Thúy Vy","Thúy Vân","Thơ Thơ","Thư Lâm","Thư Sương","Thương Huyền","Thương Nga",
"Thương Thương","Thường Xuân","Thạch Thảo","Thảo Hương","Thảo Hồng","Thảo Linh","Thảo Ly","Thảo Mai","Thảo My","Thảo Nghi","Thảo Nguyên","Thảo Nhi","Thảo Quyên","Thảo Tiên","Thảo Trang",
"Thảo Uyên","Thảo Vy","Thảo Vân","Thục Anh","Thục Khuê","Thục Nhi","Thục Oanh","Thục Quyên","Thục Trang","Thục Trinh","Thục Tâm","Thục Uyên","Thục Vân","Thục Ðoan","Thục Ðào","Thục Ðình",
"Thụy Du","Thụy Khanh","Thụy Linh","Thụy Lâm","Thụy Miên","Thụy Nương","Thụy Trinh","Thụy Trâm","Thụy Uyên","Thụy Vân","Thụy Ðào","Thủy Hằng","Thủy Hồng","Thủy Linh","Thủy Minh","Thủy Nguyệt",
"Thủy Quỳnh","Thủy Tiên","Thủy Trang","Thủy Tâm","Tinh Tú","Tiên Phương","Tiểu Mi","Tiểu My","Tiểu Quỳnh","Trang Anh","Trang Linh","Trang Nhã","Trang Tâm","Trang Ðài","Triều Nguyệt","Triều Thanh",
"Triệu Mẫn","Trung Anh","Trà Giang","Trà My","Trâm Anh","Trâm Oanh","Trân Châu","Trúc Chi","Trúc Lam","Trúc Lan","Trúc Linh","Trúc Liên","Trúc Loan","Trúc Ly","Trúc Lâm","Trúc Mai","Trúc Phương",
"Trúc Quân","Trúc Quỳnh","Trúc Vy","Trúc Vân","Trúc Ðào","Trúc Đào","Trầm Hương","Tuyết Anh","Tuyết Băng","Tuyết Chi","Tuyết Hoa","Tuyết Hân","Tuyết Hương","Tuyết Hồng","Tuyết Lan","Tuyết Loan",
"Tuyết Lâm","Tuyết Mai","Tuyết Nga","Tuyết Nhi","Tuyết Nhung","Tuyết Oanh","Tuyết Thanh","Tuyết Trinh","Tuyết Trầm","Tuyết Tâm","Tuyết Vy","Tuyết Vân","Tuyết Xuân","Tuyền Lâm","Tuệ Lâm","Tuệ Mẫn",
"Tuệ Nhi","Tâm Hiền","Tâm Hạnh","Tâm Hằng","Tâm Khanh","Tâm Linh","Tâm Nguyên","Tâm Nguyệt","Tâm Nhi","Tâm Như","Tâm Thanh","Tâm Trang","Tâm Ðoan","Tâm Đan","Tùng Linh","Tùng Lâm","Tùng Quân",
"Tùy Anh","Tùy Linh","Tú Anh","Tú Ly","Tú Nguyệt","Tú Quyên","Tú Quỳnh","Tú Sương","Tú Trinh","Tú Tâm","Tú Uyên","Túy Loan","Tường Chinh","Tường Vi","Tường Vy","Tường Vân","Tịnh Lâm","Tịnh Nhi",
"Tịnh Như","Tịnh Tâm","Tịnh Yên","Tố Loan","Tố Nga","Tố Nhi","Tố Quyên","Tố Tâm","Tố Uyên","Từ Dung","Từ Ân","Uyên Minh","Uyên My","Uyên Nhi","Uyên Phương","Uyên Thi","Uyên Thy","Uyên Thơ",
"Uyên Trâm","Uyên Vi","Uyển Khanh","Uyển My","Uyển Nghi","Uyển Nhi","Uyển Nhã","Uyển Như","Vi Quyên","Vinh Diệu","Việt Hà","Việt Hương","Việt Khuê","Việt Mi","Việt Nga","Việt Nhi","Việt Thi",
"Việt Trinh","Việt Tuyết","Việt Yến","Vy Lam","Vy Lan","Vàng Anh","Vành Khuyên","Vân Anh","Vân Chi","Vân Du","Vân Hà","Vân Hương","Vân Khanh","Vân Khánh","Vân Linh","Vân Ngọc","Vân Nhi","Vân Phi",
"Vân Phương","Vân Quyên","Vân Quỳnh","Vân Thanh","Vân Thúy","Vân Thường","Vân Tiên","Vân Trang","Vân Trinh","Vũ Hồng","Xuyến Chi","Xuân Bảo","Xuân Dung","Xuân Hiền","Xuân Hoa","Xuân Hân","Xuân Hương",
"Xuân Hạnh","Xuân Lan","Xuân Linh","Xuân Liễu","Xuân Loan","Xuân Lâm","Xuân Mai","Xuân Nghi","Xuân Ngọc","Xuân Nhi","Xuân Nhiên","Xuân Nương","Xuân Phương","Xuân Phượng","Xuân Thanh","Xuân Thu","Xuân Thảo","Xuân Thủy","Xuân Trang","Xuân Tâm","Xuân Uyên","Xuân Vân","Xuân Yến","Xuân xanh",
"Yên Bằng","Yên Mai","Yên Nhi","Yên Ðan","Yên Đan","Yến Anh","Yến Hồng","Yến Loan","Yến Mai","Yến My","Yến Nhi","Yến Oanh","Yến Phương","Yến Phượng","Yến Thanh","Yến Thảo","Yến Trang","Yến Trinh","Yến Trâm","Yến Ðan","Ái Hồng","Ái Khanh","Ái Linh","Ái Nhi","Ái Nhân","Ái Thi","Ái Thy","Ái Vân","Ánh Dương","Ánh Hoa","Ánh Hồng","Ánh Linh","Ánh Lệ","Ánh Mai","Ánh Nguyệt","Ánh Ngọc","Ánh Thơ","Ánh Trang","Ánh Tuyết","Ánh Xuân","Ðan Khanh","Ðan Quỳnh","Ðan Thu","Ðinh Hương","Ðoan Thanh","Ðoan Trang","Ðài Trang","Ðông Nghi","Ðông Nhi","Ðông Trà","Ðông Tuyền","Ðông Vy","Ðông Ðào","Ðồng Dao","Ý Bình","Ý Lan","Ý Nhi","Đan Linh","Đan Quỳnh","Đan Thanh","Đan Thu","Đan Thư",
"Đan Tâm","Đinh Hương","Đoan Thanh","Đoan Trang","Đài Trang","Đông Nghi","Đông Trà","Đông Tuyền","Đông Vy","Đơn Thuần","Đức Hạnh","Ấu Lăng","An Cơ","An Khang","Ân Lai","An Nam","An Nguyên","An Ninh","An Tâm","Ân Thiện","An Tường","Anh Ðức","Anh Dũng","Anh Duy","Anh Hoàng","Anh Khải","Anh Khoa","Anh Khôi","Anh Minh","Anh Quân","Anh Quốc","Anh Sơn","Anh Tài","Anh Thái","Anh Tú","Anh Tuấn","Anh Tùng","Anh Việt","Anh Vũ","Bá Cường","Bá Kỳ","Bá Lộc","Bá Long","Bá Phước","Bá Thành","Bá Thiện","Bá Thịnh","Bá Thúc","Bá Trúc","Bá Tùng","Bách Du","Bách Nhân","Bằng Sơn","Bảo An","Bảo Bảo","Bảo Chấn","Bảo Ðịnh","Bảo Duy","Bảo Giang","Bảo Hiển","Bảo Hoa","Bảo Hoàng","Bảo Huy","Bảo Huynh","Bảo Huỳnh","Bảo Khánh","Bảo Lâm","Bảo Long","Bảo Pháp","Bảo Quốc",
"Bảo Sơn","Bảo Thạch","Bảo Thái","Bảo Tín","Bảo Toàn","Bích Nhã","Bình An","Bình Dân","Bình Ðạt","Bình Ðịnh","Bình Dương","Bình Hòa","Bình Minh","Bình Nguyên","Bình Quân","Bình Thuận","Bình Yên","Bửu Chưởng","Bửu Diệp","Bữu Toại","Cảnh Tuấn","Cao Kỳ","Cao Minh","Cao Nghiệp","Cao Nguyên","Cao Nhân","Cao Phong",
"Cao Sĩ","Cao Sơn","Cao Sỹ","Cao Thọ","Cao Tiến","Cát Tường","Cát Uy","Chấn Hùng","Chấn Hưng","Chấn Phong","Chánh Việt","Chế Phương","Chí Anh","Chí Bảo","Chí Công","Chí Dũng","Chí Giang","Chí Hiếu","Chí Khang","Chí Khiêm","Chí Kiên","Chí Nam","Chí Sơn","Chí Thanh","Chí Thành","Chiến Thắng","Chiêu Minh","Chiêu Phong","Chiêu Quân","Chính Tâm","Chính Thuận","Chính Trực","Chuẩn Khoa","Chung Thủy","Công Án","Công Ân","Công Bằng","Công Giang","Công Hải","Công Hào","Công Hậu","Công Hiếu","Công Hoán","Công Lập","Công Lộc","Công Luận","Công Luật","Công Lý","Công Phụng","Công Sinh","Công Sơn","Công Thành","Công Tráng","Công Tuấn","Cường Dũng","Cương Nghị","Cương Quyết","Cường Thịnh","Ðắc Cường","Ðắc Di","Ðắc Lộ","Ðắc Lực","Ðắc Thái","Ðắc Thành","Ðắc Trọng","Ðại Dương","Ðại Hành","Ðại Ngọc","Ðại Thống","Dân Hiệp","Dân Khánh","Ðan Quế","Ðan Tâm","Ðăng An","Ðăng Ðạt","Ðăng Khánh","Ðăng Khoa","Đăng Khương","Ðăng Minh","Đăng Quang","Danh Nhân","Danh Sơn","Danh Thành","Danh Văn","Ðạt Dũng","Ðạt Hòa","Ðình Chiểu","Ðình Chương","Ðình Cường","Ðình Diệu","Ðình Ðôn","Ðình Dương","Ðình Hảo","Ðình Hợp","Ðình Kim","Ðinh Lộc","Ðình Lộc","Ðình Luận","Ðịnh Lực","Ðình Nam","Ðình Ngân","Ðình Nguyên","Ðình Nhân","Ðình Phú","Ðình Phúc","Ðình Quảng","Ðình Sang","Ðịnh Siêu","Ðình Thắng","Ðình Thiện","Ðình Toàn","Ðình Trung","Ðình Tuấn","Ðoàn Tụ","Ðồng Bằng","Ðông Dương","Ðông Hải","Ðồng Khánh","Ðông Nguyên","Ðông Phong","Ðông Phương","Ðông Quân","Ðông Sơn","Ðức Ân","Ðức Anh",
"Ðức Bằng","Ðức Bảo","Ðức Bình","Ðức Chính","Ðức Duy","Ðức Giang","Ðức Hải","Ðức Hạnh","Đức Hòa","Ðức Hòa","Ðức Huy","Ðức Khải","Ðức Khang","Ðức Khiêm","Ðức Kiên","Ðức Long","Ðức Mạnh","Ðức Minh","Ðức Nhân","Ðức Phi","Ðức Phong","Ðức Phú","Ðức Quang","Ðức Quảng","Ðức Quyền","Ðức Siêu","Ðức Sinh","Ðức Tài","Ðức Tâm","Ðức Thắng","Ðức Thành","Ðức Thọ","Ðức Toàn","Ðức Toản","Ðức Trí","Ðức Trung","Ðức Tuấn","Ðức Tuệ","Ðức Tường","Dũng Trí","Dũng Việt","Dương Anh","Dương Khánh","Duy An","Duy Bảo","Duy Cẩn","Duy Cường","Duy Hải","Duy Hiền","Duy Hiếu","Duy Hoàng","Duy Hùng","Duy Khang","Duy Khánh","Duy Khiêm","Duy Kính","Duy Luận","Duy Mạnh","Duy Minh","Duy Ngôn","Duy Nhượng","Duy Quang","Duy Tâm","Duy Tân","Duy Thạch","Duy Thắng","Duy Thanh","Duy Thành","Duy Thông","Duy Tiếp","Duy Tuyền","Gia Ân","Gia Anh","Gia Bạch","Gia Bảo","Gia Bình","Gia Cần","Gia Cẩn","Gia Cảnh","Gia Ðạo","Gia Ðức","Gia Hiệp","Gia Hòa","Gia Hoàng",
"Gia Huấn","Gia Hùng","Gia Hưng","Gia Huy","Gia Khánh","Gia Khiêm","Gia Kiên","Gia Kiệt","Gia Lập","Gia Minh","Gia Nghị","Gia Phong","Gia Phúc","Gia Phước","Gia Thiện","Gia Thịnh","Gia Uy","Gia Vinh","Giang Lam","Giang Nam","Giang Sơn","Giang Thiên","Hà Hải","Hải Bằng","Hải Bình","Hải Ðăng","Hải Dương","Hải Giang","Hải Hà","Hải Long","Hải Lý","Hải Nam","Hải Nguyên","Hải Phong","Hải Quân","Hải Sơn","Hải Thụy","Hán Lâm","Hạnh Tường","Hào Nghiệp","Hạo Nhiên","Hiền Minh","Hiệp Dinh","Hiệp Hà","Hiệp Hào","Hiệp Hiền","Hiệp Hòa","Hiệp Vũ","Hiếu Dụng","Hiếu Học","Hiểu Lam","Hiếu Liêm","Hiếu Nghĩa","Hiếu Phong","Hiếu Thông","Hồ Bắc","Hồ Nam","Hòa Bình","Hòa Giang","Hòa Hiệp","Hòa Hợp","Hòa Lạc","Hòa Thái","Hoài Bắc","Hoài Nam","Hoài Phong","Hoài Thanh","Hoài Tín","Hoài Trung","Hoài Việt","Hoài Vỹ","Hoàn Kiếm","Hoàn Vũ","Hoàng Ân","Hoàng Duệ","Hoàng Dũng","Hoàng Giang","Hoàng Hải","Hoàng Hiệp","Hoàng Khải","Hoàng Khang","Hoàng Khôi","Hoàng Lâm","Hoàng Linh","Hoàng Long","Hoàng Minh","Hoàng Mỹ","Hoàng Nam","Hoàng Ngôn","Hoàng Phát","Hoàng Quân","Hoàng Thái","Hoàng Việt","Hoàng Xuân","Hồng Ðăng","Hồng Đức","Hồng Giang","Hồng Lân","Hồng Liêm","Hồng Lĩnh","Hồng Minh","Hồng Nhật","Hồng Nhuận","Hồng Phát","Hồng Quang","Hồng Quý","Hồng Sơn","Hồng Thịnh","Hồng Thụy","Hồng Việt","Hồng Vinh","Huân Võ","Hùng Anh","Hùng Cường","Hưng Ðạo","Hùng Dũng","Hùng Ngọc","Hùng Phong",
"Hùng Sơn","Hùng Thịnh","Hùng Tường","Hướng Bình","Hướng Dương","Hướng Thiện","Hướng Tiền","Hữu Bào","Hữu Bảo","Hữu Bình","Hữu Canh","Hữu Cảnh","Hữu Châu","Hữu Chiến","Hữu Cương","Hữu Cường","Hữu Ðạt","Hữu Ðịnh","Hữu Hạnh","Hữu Hiệp","Hữu Hoàng","Hữu Hùng","Hữu Khang","Hữu Khanh","Hữu Khoát","Hữu Khôi","Hữu Long","Hữu Lương","Hữu Minh","Hữu Nam","Hữu Nghị","Hữu Nghĩa","Hữu Phước","Hữu Tài","Hữu Tâm","Hữu Tân","Hữu Thắng","Hữu Thiện","Hữu Thọ","Hữu Thống","Hữu Thực","Hữu Toàn","Hữu Trác","Hữu Trí","Hữu Trung","Hữu Từ","Hữu Tường","Hữu Vĩnh","Hữu Vượng","Huy Anh","Huy Chiểu","Huy Hà","Huy Hoàng","Huy Kha","Huy Khánh","Huy Khiêm","Huy Lĩnh","Huy Phong","Huy Quang","Huy Thành","Huy Thông","Huy Trân","Huy Tuấn","Huy Tường","Huy Việt","Huy Vũ","Khắc Anh","Khắc Công","Khắc Dũng","Khắc Duy","Khắc Kỷ","Khắc Minh","Khắc Ninh","Khắc Thành","Khắc Triệu","Khắc Trọng","Khắc Tuấn","Khắc Việt","Khắc Vũ","Khải Ca","Khải Hòa","Khai Minh","Khải Tâm","Khải Tuấn","Khang Kiện","Khánh An","Khánh Bình","Khánh Ðan","Khánh Duy",
"Khánh Giang","Khánh Hải","Khánh Hòa","Khánh Hoàn","Khánh Hoàng","Khánh Hội","Khánh Huy","Khánh Minh","Khánh Nam","Khánh Văn","Khoa Trưởng","Khôi Nguyên","Khởi Phong","Khôi Vĩ","Khương Duy","Khuyến Học","Kiên Bình","Kiến Bình","Kiên Cường","Kiến Ðức","Kiên Giang","Kiên Lâm","Kiên Trung","Kiến Văn","Kiệt Võ","Kim Ðan","Kim Hoàng","Kim Long","Kim Phú","Kim Sơn","Kim Thịnh","Kim Thông","Kim Toàn","Kim Vượng","Kỳ Võ","Lạc Nhân","Lạc Phúc","Lâm Ðồng","Lâm Dũng","Lam Giang","Lam Phương","Lâm Trường","Lâm Tường","Lâm Viên","Lâm Vũ","Lập Nghiệp","Lập Thành","Liên Kiệt","Long Giang","Long Quân","Long Vịnh","Lương Quyền","Lương Tài","Lương Thiện","Lương Tuyền","Mạnh Cương","Mạnh Cường","Mạnh Ðình","Mạnh Dũng","Mạnh Hùng","Mạnh Nghiêm","Mạnh Quỳnh","Mạnh Tấn","Mạnh Thắng","Mạnh Thiện","Mạnh Trình","Mạnh Trường","Mạnh Tuấn","Mạnh Tường","Minh Ân","Minh Anh","Minh Cảnh","Minh Dân","Minh Ðan","Minh Danh","Minh Ðạt","Minh Ðức","Minh Dũng","Minh Giang","Minh Hải","Minh Hào","Minh Hiên","Minh Hiếu","Minh Hòa","Minh Hoàng","Minh Huấn","Minh Hùng","Minh Hưng","Minh Huy","Minh Hỷ","Minh Khang","Minh Khánh","Minh Khiếu","Minh Khôi","Minh Kiệt","Minh Kỳ","Minh Lý","Minh Mẫn","Minh Nghĩa","Minh Nhân","Minh Nhật","Minh Nhu","Minh Quân","Minh Quang","Minh Quốc","Minh Sơn","Minh Tân","Minh Thạc","Minh Thái","Minh Thắng","Minh Thiện","Minh Thông","Minh Thuận","Minh Tiến","Minh Toàn","Minh Trí","Minh Triết","Minh Triệu",
"Minh Trung","Minh Tú","Minh Tuấn","Minh Vu","Minh Vũ","Minh Vương","Mộng Giác","Mộng Hoàn","Mộng Lâm","Mộng Long","Nam An","Nam Dương","Nam Hải","Nam Hưng","Nam Lộc","Nam Nhật","Nam Ninh","Nam Phi","Nam Phương","Nam Sơn","Nam Thanh",
"Nam Thông","Nam Tú","Nam Việt","Nghị Lực","Nghị Quyền","Nghĩa Dũng","Nghĩa Hòa","Ngọc Ẩn","Ngọc Cảnh","Ngọc Cường","Ngọc Danh","Ngọc Ðoàn","Ngọc Dũng","Ngọc Hải","Ngọc Hiển","Ngọc Huy","Ngọc Khang","Ngọc Khôi","Ngọc Khương","Ngọc Lai","Ngọc Lân","Ngọc Minh","Ngọc Ngạn","Ngọc Quang","Ngọc Sơn","Ngọc Thạch","Ngọc Thiện","Ngọc Thọ","Ngọc Thuận","Ngọc Tiển","Ngọc Trụ","Ngọc Tuấn","Nguyên Bảo","Nguyên Bổng","Nguyên Ðan","Nguyên Giang","Nguyên Giáp","Nguyễn Hải An","Nguyên Hạnh","Nguyên Khang","Nguyên Khôi","Nguyên Lộc","Nguyên Nhân","Nguyên Phong","Nguyên Sử","Nguyên Văn","Nhân Nguyên","Nhân Sâm","Nhân Từ","Nhân Văn","Nhật Bảo Long","Nhật Dũng","Nhật Duy","Nhật Hòa","Nhật Hoàng","Nhật Hồng","Nhật Hùng","Nhật Huy","Nhật Khương","Nhật Minh","Nhật Nam","Nhật Quân","Nhật Quang","Nhật Quốc","Nhật Tấn","Nhật Thịnh","Nhất Tiến","Nhật Tiến","Như Khang","Niệm Nhiên","Phi Cường","Phi Ðiệp","Phi Hải","Phi Hoàng","Phi Hùng","Phi Long","Phi Nhạn","Phong Châu","Phong Dinh","Phong Ðộ","Phú Ân","Phú Bình","Phú Hải","Phú Hiệp","Phú Hùng","Phú Hưng","Phú Thịnh","Phú Thọ","Phú Thời","Phúc Cường","Phúc Ðiền","Phúc Duy","Phúc Hòa","Phúc Hưng","Phúc Khang","Phúc Lâm","Phục Lễ","Phúc Nguyên","Phúc Sinh","Phúc Tâm","Phúc Thịnh","Phụng Việt","Phước An","Phước Lộc","Phước Nguyên","Phước Nhân","Phước Sơn","Phước Thiện","Phượng Long","Phương Nam","Phương Phi","Phương Thể","Phương Trạch","Phương Triều","Quân Dương",
"Quang Anh","Quang Bửu","Quảng Ðại","Quang Danh","Quang Ðạt","Quảng Ðạt","Quang Ðức","Quang Dũng","Quang Dương","Quang Hà","Quang Hải","Quang Hòa","Quang Hùng","Quang Hưng","Quang Hữu","Quang Huy","Quang Khải","Quang Khanh","Quang Lâm","Quang Lân","Quang Linh","Quang Lộc","Quang Minh",
"Quang Nhân","Quang Nhật","Quang Ninh","Quang Sáng","Quang Tài","Quang Thạch","Quang Thái","Quang Thắng","Quang Thiên","Quang Thịnh","Quảng Thông","Quang Thuận","Quang Triều","Quang Triệu","Quang Trọng","Quang Trung","Quang Trường","Quang Tú","Quang Tuấn","Quang Vinh","Quang Vũ","Quang Xuân","Quốc Anh","Quốc Bảo","Quốc Bình","Quốc Ðại","Quốc Ðiền","Quốc Hải","Quốc Hạnh","Quốc Hiền","Quốc Hiển","Quốc Hòa",
"Quốc Hoài","Quốc Hoàng","Quốc Hùng","Quốc Hưng","Quốc Huy","Quốc Khánh","Quốc Mạnh","Quốc Minh","Quốc Mỹ","Quốc Phong","Quốc Phương","Quốc Quân","Quốc Quang","Quốc Quý","Quốc Thắng","Quốc Thành","Quốc Thiện","Quốc Thịnh","Quốc Thông","Quốc Tiến","Quốc Toản","Quốc Trụ","Quốc Trung","Quốc Trường","Quốc Tuấn","Quốc Văn","Quốc Việt","Quốc Vinh","Quốc Vũ","Quý Khánh","Quý Vĩnh","Quyết Thắng","Sĩ Hoàng","Sơn Dương","Sơn Giang","Sơn Hà","Sơn Hải","Sơn Lâm","Sơn Quân","Sơn Quyền","Sơn Trang","Sơn Tùng","Song Lam","Sỹ Ðan","Sỹ Hoàng","Sỹ Phú","Sỹ Thực","Tạ Hiền","Tài Ðức","Tài Nguyên","Tâm Thiện","Tân Bình","Tân Ðịnh","Tấn Dũng","Tấn Khang","Tấn Lợi","Tân Long","Tấn Nam","Tấn Phát","Tân Phước","Tấn Sinh","Tấn Tài","Tân Thành","Tấn Thành","Tấn Trình","Tấn Trương","Tất Bình","Tất Hiếu","Tất Hòa",
"Thạch Sơn","Thạch Tùng","Thái Bình","Thái Ðức","Thái Dương","Thái Duy","Thái Hòa","Thái Minh","Thái Nguyên","Thái San","Thái Sang","Thái Sơn","Thái Tân","Thái Tổ","Thắng Cảnh","Thắng Lợi","Thăng Long","Thành An","Thành Ân","Thành Châu","Thành Công","Thành Danh","Thanh Ðạo","Thành Ðạt","Thành Ðệ","Thanh Ðoàn","Thành Doanh","Thanh Hải","Thanh Hào","Thanh Hậu","Thành Hòa","Thanh Huy","Thành Khiêm","Thanh Kiên","Thanh Liêm","Thành Lợi","Thanh Long","Thành Long","Thanh Minh","Thành Nguyên","Thành Nhân","Thanh Phi","Thanh Phong","Thành Phương","Thanh Quang","Thành Sang","Thanh Sơn","Thanh Thế","Thanh Thiên","Thành Thiện","Thanh Thuận","Thành Tín","Thanh Tịnh","Thanh Toàn","Thanh Toản","Thanh Trung","Thành Trung","Thanh Tú","Thanh Tuấn","Thanh Tùng","Thanh Việt","Thanh Vinh","Thành Vinh","Thanh Vũ","Thành Ý","Thất Cương","Thất Dũng","Thất Thọ","Thế An","Thế Anh","Thế Bình","Thế Dân","Thế Doanh","Thế Dũng","Thế Duyệt","Thế Huấn","Thế Hùng","Thế Lâm","Thế Lực","Thế Minh","Thế Năng","Thế Phúc","Thế Phương","Thế Quyền","Thế Sơn","Thế Trung","Thế Tường","Thế Vinh","Thiên An","Thiên Ân","Thiện Ân","Thiên Bửu","Thiên Ðức","Thiện Ðức","Thiện Dũng","Thiện Giang","Thiên Hưng","Thiện Khiêm","Thiên Lạc","Thiện Luân","Thiên Lương","Thiện Lương","Thiên Mạnh","Thiện Minh","Thiện Ngôn","Thiên Phú","Thiện Phước","Thiện Sinh","Thiện Tâm","Thiện Thanh","Thiện Tính","Thiên Trí","Thiếu Anh","Thiệu Bảo","Thiếu Cường","Thịnh Cường",
"Thời Nhiệm","Thông Ðạt","Thông Minh","Thống Nhất","Thông Tuệ","Thụ Nhân","Thu Sinh","Thuận Anh","Thuận Hòa","Thuận Phong","Thuận Phương","Thuận Thành","Thuận Toàn","Thượng Cường","Thượng Khang","Thường Kiệt","Thượng Liệt","Thượng Năng","Thượng Nghị","Thượng Thuật","Thường Xuân","Thụy Du",
"Thụy Long","Thụy Miên","Thụy Vũ","Tích Ðức","Tích Thiện","Tiến Ðức","Tiến Dũng","Tiền Giang","Tiến Hiệp","Tiến Hoạt","Tiến Võ","Tiểu Bảo","Toàn Thắng","Tôn Lễ","Trí Dũng","Trí Hào","Trí Hùng","Trí Hữu","Trí Liên","Trí Minh","Trí Thắng","Trí Tịnh","Triển Sinh","Triệu Thái","Triều Thành","Trọng Chính","Trọng Dũng","Trọng Duy","Trọng Hà","Trọng Hiếu","Trọng Hùng","Trọng Khánh",
"Trọng Kiên","Trọng Nghĩa","Trọng Nhân","Trọng Tấn","Trọng Trí","Trọng Tường","Trọng Việt","Trọng Vinh","Trúc Cương","Trúc Sinh","Trung Anh","Trung Chính","Trung Chuyên","Trung Ðức","Trung Dũng","Trung Hải","Trung Hiếu","Trung Kiên","Trung Lực","Trung Nghĩa","Trung Nguyên","Trung Nhân","Trung Thành","Trung Thực","Trung Việt","Trường An","Trường Chinh","Trường Giang","Trường Hiệp",
"Trường Kỳ","Trường Liên","Trường Long","Trường Nam","Trường Nhân","Trường Phát","Trường Phu","Trường Phúc","Trường Sa","Trường Sinh","Trường Sơn","Trường Thành","Trường Vinh","Trường Vũ","Từ Ðông","Tuấn Anh","Tuấn Châu","Tuấn Chương","Tuấn Ðức","Tuấn Dũng","Tuấn Hải","Tuấn Hoàng","Tuấn Hùng","Tuấn Khải","Tuấn Khanh","Tuấn Khoan","Tuấn Kiệt","Tuấn Linh","Tuấn Long","Tuấn Minh","Tuấn Ngọc","Tuấn Sĩ","Tuấn Sỹ","Tuấn Tài","Tuấn Thành","Tuấn Trung","Tuấn Tú","Tuấn Việt",
"Tùng Anh","Tùng Châu","Tùng Lâm","Tùng Linh","Tùng Minh","Tùng Quang","Tường Anh","Tường Lâm","Tường Lân","Tường Lĩnh","Tường Minh","Tường Nguyên","Tường Phát","Tường Vinh","Tuyền Lâm","Uy Phong","Uy Vũ","Vạn Hạnh","Vạn Lý","Văn Minh","Vân Sơn","Vạn Thắng","Vạn Thông","Văn Tuyển","Viễn Cảnh","Viễn Ðông","Viễn Phương","Viễn Thông","Việt An","Việt Anh","Việt Chính","Việt Cương","Việt Cường","Việt Dũng","Việt Dương","Việt Duy","Việt Hải","Việt Hoàng","Việt Hồng","Việt Hùng","Việt Huy","Việt Khải","Việt Khang","Việt Khoa","Việt Khôi","Việt Long","Việt Ngọc","Viết Nhân","Việt Nhân","Việt Phong","Việt Phương","Việt Quốc","Việt Quyết","Viết Sơn","Việt Sơn","Viết Tân","Việt Thái","Việt Thắng","Việt Thanh","Việt Thông","Việt Thương","Việt Tiến","Việt Võ","Vĩnh Ân","Vinh Diệu","Vĩnh Hải","Vĩnh Hưng","Vĩnh Long","Vĩnh Luân","Vinh Quốc","Vĩnh Thọ","Vĩnh Thụy","Vĩnh Toàn","Vũ Anh","Vũ Minh","Vương Gia","Vương Triều","Vương Triệu","Vương Việt","Xuân An","Xuân Bình","Xuân Cao","Xuân Cung","Xuân Hàm","Xuân Hãn","Xuân Hiếu","Xuân Hòa","Xuân Huy","Xuân Khoa","Xuân Kiên","Xuân Lạc","Xuân Lộc","Xuân Minh","Xuân Nam","Xuân Ninh","Xuân Phúc","Xuân Quân","Xuân Quý","Xuân Sơn","Xuân Thái","Xuân Thiện","Xuân Thuyết","Xuân Trung","Xuân Trường","Xuân Tường",
"Xuân Vũ","Yên Bằng","Yên Bình","Yên Sơn"
                   };
        public static List<string> FirtnamesVN = new List<string>
            {
                    "Nguyễn","Trần","Lê","Phạm","Hoàng","Huỳnh","Phan","Võ","Đặng","Bùi","Đỗ","Hồ","Dương","Lý","An","Đào","Đinh","Trịnh","Lương","Kiều","Chu","Ninh","Cao","Kim","Quách","Trương","Quang","Đoàn","Mai","Tô","Vương","Lưu","Ngô","Ho","Vũ","Dịch","Hà","Đặng","Cung","Tạ","Đoàn","Từ","Phùng","Lê","Phan","Dương","Đoàn","Nguyễn","Lê","Trần","Hoàng","Võ","Phạm","Lý","Dương","Cao","Đỗ","Chu","Nguyễn","Đào","Lê","Mai","Lương","Phan","Kim","Ho","Chu","Phạm","Tăng","Đoàn","Thái","Tiết","Hồ","Đoàn","Vũ","Đỗ","Chu","Dương","Nguyễn","Bùi","Chu","Lê","Lưu","Trương","Hoàng","Chu","Kiều","Trần","Đào","Cao","Vương","Phan","Phạm","Hà","Đoàn","Đặng","Quách","Trần","Cung","Chu"
                   };
        public static List<string> FirtnamesUS = new List<string>
            {
                   "SMITH","JOHNSON","WILLIAMS","JONES","BROWN","DAVIS","MILLER","WILSON","MOORE","TAYLOR","ANDERSON","THOMAS","JACKSON","WHITE","HARRIS","MARTIN","THOMPSON","GARCIA","MARTINEZ","ROBINSON","CLARK","RODRIGUEZ","LEWIS","LEE","WALKER","HALL","ALLEN","YOUNG","HERNANDEZ","KING","WRIGHT","LOPEZ","HILL","SCOTT","GREEN","ADAMS","BAKER","GONZALEZ","NELSON","CARTER","MITCHELL","PEREZ","ROBERTS","TURNER","PHILLIPS","CAMPBELL","PARKER","EVANS","EDWARDS","COLLINS","STEWART","SANCHEZ","MORRIS","ROGERS","REED","COOK","MORGAN","BELL","MURPHY","BAILEY","RIVERA","COOPER","RICHARDSON","COX","HOWARD","WARD","TORRES","PETERSON","GRAY","RAMIREZ","JAMES","WATSON","BROOKS","KELLY","SANDERS","PRICE","BENNETT","WOOD","BARNES","ROSS","HENDERSON","COLEMAN","JENKINS","PERRY","POWELL","LONG","PATTERSON","HUGHES","FLORES","WASHINGTON","BUTLER","SIMMONS","FOSTER","GONZALES","BRYANT","ALEXANDER","RUSSELL","GRIFFIN","DIAZ","HAYES","MYERS","FORD","HAMILTON","GRAHAM","SULLIVAN","WALLACE","WOODS","COLE","WEST","JORDAN","OWENS","REYNOLDS","FISHER","ELLIS","HARRISON","GIBSON","MCDONALD","CRUZ","MARSHALL","ORTIZ","GOMEZ","MURRAY","FREEMAN","WELLS","WEBB","SIMPSON","STEVENS","TUCKER","PORTER","HUNTER","HICKS","CRAWFORD","HENRY","BOYD","MASON","MORALES","KENNEDY","WARREN","DIXON","RAMOS","REYES","BURNS","GORDON","SHAW","HOLMES","RICE","ROBERTSON","HUNT","BLACK","DANIELS","PALMER","MILLS","NICHOLS","GRANT","KNIGHT","FERGUSON","ROSE","STONE","HAWKINS","DUNN","PERKINS","HUDSON","SPENCER","GARDNER","STEPHENS","PAYNE","PIERCE","BERRY","MATTHEWS","ARNOLD","WAGNER","WILLIS","RAY","WATKINS","OLSON","CARROLL","DUNCAN","SNYDER","HART","CUNNINGHAM","BRADLEY","LANE","ANDREWS","RUIZ","HARPER","FOX","RILEY","ARMSTRONG","CARPENTER","WEAVER","GREENE","LAWRENCE","ELLIOTT","CHAVEZ","SIMS","AUSTIN","PETERS","KELLEY","FRANKLIN","LAWSON","FIELDS","GUTIERREZ","RYAN"
                   };
        public static List<string> LastnamesUS = new List<string>
            {
                 "Smith","Johnson","Williams","Brown","Jones","Garcia","Miller","Davis","Rodriguez","Martinez","Hernandez","Lopez","Gonzalez","Wilson","Anderson","Thomas","Taylor","Moore","Jackson","Martin","Lee",
"Perez","Thompson","White","Harris","Sanchez","Clark","Ramirez","Lewis","Robinson","Walker","Young","Allen","King","Wright","Scott","Torres","Nguyen","Hill","Flores","Green","Adams","Nelson","Baker",
"Hall","Rivera","Campbell","Mitchell","Carter","Roberts","Gomez","Phillips","Evans","Turner","Diaz","Parker","Cruz","Edwards","Collins","Reyes","Stewart","Morris","Morales","Murphy","Cook","Rogers",
"Gutierrez","Ortiz","Morgan","Cooper","Peterson","Bailey","Reed","Kelly","Howard","Ramos","Kim","Cox","Ward","Richardson","Watson","Brooks","Chavez","Wood","James","Bennett","Gray","Mendoza","Ruiz",
"Hughes","Price","Alvarez","Castillo","Sanders","Patel","Myers","Long","Ross","Foster","Jimenez","Powell","Jenkins","Perry","Russell","Sullivan","Bell","Coleman","Butler","Henderson","Barnes","Gonzales",
"Fisher","Vasquez","Simmons","Romero","Jordan","Patterson","Alexander","Hamilton","Graham","Reynolds","Griffin","Wallace","Moreno","West","Cole","Hayes","Bryant","Herrera","Gibson","Ellis","Tran",
"Medina","Aguilar","Stevens","Murray","Ford","Castro","Marshall","Owens","Harrison","Fernandez","Mcdonald","Woods","Washington","Kennedy","Wells","Vargas","Henry","Chen","Freeman","Webb","Tucker",
"Guzman","Burns","Crawford","Olson","Simpson","Porter","Hunter","Gordon","Mendez","Silva","Shaw","Snyder","Mason","Dixon","Munoz","Hunt","Hicks","Holmes","Palmer","Wagner","Black","Robertson","Boyd",
"Rose","Stone","Salazar","Fox","Warren","Mills","Meyer","Rice","Schmidt","Garza","Daniels","Ferguson","Nichols","Stephens","Soto","Weaver","Ryan","Gardner","Payne","Grant","Dunn","Kelley","Spencer",
"Hawkins","Arnold","Pierce","Vazquez","Hansen","Peters","Santos","Hart","Bradley","Knight","Elliott","Cunningham","Duncan","Armstrong","Hudson","Carroll","Lane","Riley","Andrews","Alvarado","Ray",
"Delgado","Berry","Perkins","Hoffman","Johnston","Matthews","Pena","Richards","Contreras","Willis","Carpenter","Lawrence","Sandoval","Guerrero","George","Chapman","Rios","Estrada","Ortega","Watkins",
"Greene","Nunez","Wheeler","Valdez","Harper","Burke","Larson","Santiago","Maldonado","Morrison","Franklin","Carlson","Austin","Dominguez","Carr","Lawson","Jacobs","Obrien","Lynch","Singh","Vega",
"Bishop","Montgomery","Oliver","Jensen","Harvey","Williamson","Gilbert","Dean","Sims","Espinoza","Howell","Li","Wong","Reid","Hanson","Le","Mccoy","Garrett","Burton","Fuller","Wang","Weber","Welch",
"Rojas","Lucas","Marquez","Fields","Park","Yang","Little","Banks","Padilla","Day","Walsh","Bowman","Schultz","Luna","Fowler","Mejia","Davidson","Acosta","Brewer","May","Holland","Juarez","Newman",
"Pearson","Curtis","Cortez","Douglas","Schneider","Joseph","Barrett","Navarro","Figueroa","Keller","Avila","Wade","Molina","Stanley","Hopkins","Campos","Barnett","Bates","Chambers","Caldwell","Beck",
"Lambert","Miranda","Byrd","Craig","Ayala","Lowe","Frazier","Powers","Neal","Leonard","Gregory","Carrillo","Sutton","Fleming","Rhodes","Shelton","Schwartz","Norris","Jennings","Watts","Duran","Walters",
"Cohen","Mcdaniel","Moran","Parks","Steele","Vaughn","Becker","Holt","Deleon","Barker","Terry","Hale","Leon","Hail","Benson","Haynes","Horton","Miles","Lyons","Pham","Graves","Bush","Thornton","Wolfe","Warner","Cabrera","Mckinney","Mann","Zimmerman","Dawson","Lara","Fletcher","Page","Mccarthy","Love","Robles","Cervantes","Solis","Erickson","Reeves","Chang","Klein","Salinas","Fuentes","Baldwin","Daniel","Simon","Velasquez","Hardy","Higgins","Aguirre","Lin","Cummings","Chandler","Sharp","Barber","Bowen","Ochoa","Dennis","Robbins","Liu","Ramsey","Francis","Griffith","Paul","Blair","Oconnor","Cardenas","Pacheco","Cross","Calderon","Quinn",
"Moss","Swanson","Chan","Rivas","Khan","Rodgers","Serrano","Fitzgerald","Rosales","Stevenson","Christensen","Manning","Gill","Curry","Mclaughlin","Harmon","Mcgee","Gross","Doyle","Garner","Newton",
"Burgess","Reese","Walton","Blake","Trujillo","Adkins","Brady","Goodman","Roman","Webster","Goodwin","Fischer","Huang","Potter","Delacruz","Montoya","Todd","Wu","Hines","Mullins","Castaneda","Malone","Cannon","Tate","Mack","Sherman","Hubbard","Hodges","Zhang","Guerra","Wolf","Valencia","Franco","Saunders","Rowe","Gallagher","Farmer","Hammond","Hampton","Townsend","Ingram","Wise","Gallegos","Clarke","Barton","Schroeder","Maxwell","Waters","Logan","Camacho","Strickland","Norman","Person","Colon","Parsons","Frank","Harrington","Glover","Osborne","Buchanan","Casey","Floyd","Patton","Ibarra","Ball","Tyler","Suarez","Bowers","Orozco","Salas","Cobb","Gibbs","Andrade","Bauer","Conner","Moody","Escobar","Mcguire","Lloyd","Mueller","Hartman","French","Kramer","Mcbride","Pope",
"Lindsey","Velazquez","Norton","Mccormick","Sparks","Flynn","Yates","Hogan","Marsh","Macias","Villanueva","Zamora","Pratt","Stokes","Owen","Ballard","Lang","Brock","Villarreal","Charles","Drake","Barrera","Cain","Patrick","Pineda","Burnett","Mercado","Santana","Shepherd","Bautista","Ali","Shaffer","Lamb","Trevino","Mckenzie","Hess","Beil","Olsen","Cochran","Morton","Nash","Wilkins","Petersen","Briggs","Shah","Roth","Nicholson","Holloway","Lozano","Flowers","Rangel","Hoover","Arias","Short","Mora","Valenzuela","Bryan","Meyers","Weiss","Underwood","Bass","Greer","Summers","Houston","Carson","Morrow","Clayton","Whitaker","Decker","Yoder","Collier","Zuniga","Carey","Wilcox","Melendez","Poole","Roberson","Larsen","Conley","Davenport","Copeland","Massey","Lam",
"Huff","Rocha","Cameron","Jefferson","Hood","Monroe","Anthony","Pittman","Huynh","Randall","Singleton","Kirk","Combs","Mathis","Christian","Skinner","Bradford","Richard","Galvan","Wall","Boone","Kirby","Wilkinson","Bridges","Bruce","Atkinson","Velez","Meza","Roy","Vincent","York","Hodge","Villa","Abbott","Allison","Tapia","Gates","Chase","Sosa","Sweeney","Farrell","Wyatt","Dalton","Horn","Barron","Phelps","Yu","Dickerson","Heath","Foley","Atkins","Mathews","Bonilla","Acevedo","Benitez","Zavala","Hensley","Glenn","Cisneros","Harrell","Shields","Rubio","Choi","Huffman","Boyer","Garrison","Arroyo","Bond","Kane","Hancock","Callahan","Dillon","Cline","Wiggins",
"Grimes","Arellano","Melton","Oneill","Savage","Ho","Beltran","Pitts","Parrish","Ponce","Rich","Booth","Koch","Golden","Ware","Brennan","Mcdowell","Marks","Cantu","Humphrey","Baxter","Sawyer","Clay","Tanner","Hutchinson","Kaur","Berg","Wiley","Gilmore","Russo","Villegas","Hobbs","Keith","Wilkerson","Ahmed","Beard","Mcclain","Montes","Mata","Rosario","Vang","S","S","Walter","Henson","Oneal","Mosley","Mcclure","Beasley","Stephenson","Snow","Huerta","Preston","Vance","Barry","Johns","Eaton","Blackwell","Dyer","Prince","Macdonald","Solomon","Guevara","Stafford","English","Hurst","Woodard","Cortes","Shannon","Kemp","Nolan","Mccullough","Merritt","Murillo","Moon","Salgado","Strong","Kline","Cordova","Barajas","Roach","Rosas","Winters","Jacobson",
"Lester","Knox","Bullock","Kerr","Leach","Meadows","Davila","Orr","Whitehead","Pruitt","Kent","Conway","Mckee","Barr","David","Dejesus","Marin","Berger","Mcintyre","Blankenship","Gaines","Palacios","Cuevas","Bartlett","Durham","Dorsey","Mccall","Odonnell","Stein","Browning","Stout","Lowery","Sloan","Mclean","Hendricks","Calhoun","Sexton","Chung","Gentry","Hull","Duarte","Ellison","Nielsen","Gillespie","Buck","Middleton","Sellers","Leblanc","Esparza","Hardin",
"Bradshaw","Mcintosh","Howe","Livingston","Frost","Glass","Morse","Knapp","Herman","Stark","Bravo","Noble","Spears","Weeks","Corona","Frederick","Buckley","Mcfarland","Hebert","Enriquez","Hickman","Quintero","Randolph","Schaefer","Walls","Trejo","House","Reilly","Pennington","Michael","Conrad","Giles","Benjamin","Crosby","Fitzpatrick","Donovan","Mays","Mahoney","Valentine","Raymond","Medrano","Hahn","Mcmillan","Small","Bentley","Felix","Peck","Lucero","Boyle","Hanna","Pace","Rush","Hurley","Harding","Mcconnell","Bernal","Nava","Ayers","Everett","Ventura","Avery","Pugh","Mayer",
"Bender","Shepard","Mcmahon","Landry","Case","Sampson","Moses","Magana","Blackburn","Dunlap","Gould","Duffy","Vaughan","Herring","Mckay","Espinosa","Rivers","Farley","Bernard","Ashley","Friedman",
"Potts","Truong","Costa","Correa","Blevins","Nixon","Clements","Fry","Delarosa","Best","Benton","Lugo","Portillo","Dougherty","Crane","Haley","Phan","Villalobos","Blanchard","Horne","Finley","Quintana","Lynn","Esquivel","Bean","Dodson","Mullen","Xiong",
"Hayden","Cano","Levy","Huber","Richmond","Moyer","Lim","Frye","Sheppard","Mccarty","Avalos","Booker","Waller","Parra","Woodward","Jaramillo","Krueger",
"Rasmussen","Brandt","Peralta","Donaldson","Stuart","Faulkner","Maynard","Galindo","Coffey","Estes","Sanford","Burch","Maddox","Vo","Oconnell","Vu","Andersen","Spence","Mcpherson","Church","Schmitt","Stanton","Leal","Cherry","Compton","Dudley","Sierra","Pollard","Alfaro","Hester","Proctor","Lu","Hinton","Novak","Good","Madden","Mccann",
"Terrell","Jarvis","Dickson","Reyna","Cantrell","Mayo","Branch","Hendrix","Rollins","Rowland","Whitney","Duke","Odom","Daugherty","Travis","Tang"
        };
    }
}
