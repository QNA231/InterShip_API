namespace InternShip_API.Handels.HandleImage
{
    public class HandleUpdateImage
    {
        public static async Task<string> UpdateImage(string existingFilePath, IFormFile newImageFile)
        {
            if (newImageFile == null || newImageFile.Length == 0)
            {
                // Xử lý khi không có tệp mới được chọn hoặc tệp trống
                return existingFilePath;
            }

            // Xóa tệp hình ảnh cũ
            if (File.Exists(existingFilePath))
            {
                File.Delete(existingFilePath);
            }

            // Tạo đường dẫn lưu trữ tệp tải lên mới
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Tạo tên tệp duy nhất cho tệp mới
            string uniqueFileName = Path.GetFileNameWithoutExtension(newImageFile.FileName) + "_" + Path.GetRandomFileName() + Path.GetExtension(newImageFile.FileName);

            // Đường dẫn đầy đủ của tệp lưu trữ mới
            string newFilePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Sao chép dữ liệu từ tệp tải lên mới vào tệp lưu trữ mới
            using (var stream = new FileStream(newFilePath, FileMode.Create))
            {
                await newImageFile.CopyToAsync(stream);
            }

            // Trả về đường dẫn tệp lưu trữ mới
            return newFilePath;
        }
    }
}
