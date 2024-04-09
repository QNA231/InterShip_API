namespace InternShip_API.Handels.HandleImage
{
    public class HandleUploadImage
    {
        public static async Task<string> UploadImage(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentNullException("Không có file nào được chọn");
            }

            // Tạo đường dẫn lưu trữ tệp tải lên
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Tạo tên tệp duy nhất bằng cách kết hợp tên gốc và một số ngẫu nhiên
            string uniqueFileName = Path.GetFileNameWithoutExtension(imageFile.FileName) + "_" + Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);

            // Đường dẫn đầy đủ của tệp lưu trữ
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Sao chép dữ liệu từ tệp tải lên vào tệp lưu trữ
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // Trả về đường dẫn tệp lưu trữ
            return filePath;
        }
    }
}
