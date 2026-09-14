namespace MVC031.Models
{
    public class ProductModel
    {
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "iPhone 16 Pro Max",
                    ImageURL = "https://images.unsplash.com/photo-1695048133142-1a20484d2569?w=600&auto=format&fit=crop&q=60",
                    ProductPrice = 34990000m,
                    Description = "Điện thoại Apple iPhone 16 Pro Max 256GB - Thiết kế Titan cao cấp, chip A18 Pro mạnh mẽ."
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Samsung Galaxy S24 Ultra",
                    ImageURL = "https://images.unsplash.com/photo-1610945265064-0e34e5519bbf?w=600&auto=format&fit=crop&q=60",
                    ProductPrice = 29990000m,
                    Description = "Galaxy S24 Ultra tích hợp Galaxy AI đột phá, camera zoom 100x và bút S-Pen tiện lợi."
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "MacBook Pro 14 M3",
                    ImageURL = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=600&auto=format&fit=crop&q=60",
                    ProductPrice = 39990000m,
                    Description = "Laptop Apple MacBook Pro 14 inch M3 - Màn hình Liquid Retina XDR sắc nét, pin dùng 22 giờ."
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Dell XPS 15 9530",
                    ImageURL = "https://images.unsplash.com/photo-1593642632823-8f785ba67e45?w=600&auto=format&fit=crop&q=60",
                    ProductPrice = 42500000m,
                    Description = "Laptop doanh nhân Dell XPS 15 - Màn hình 3.5K OLED, Intel Core i7 thế hệ mới và đồ họa RTX."
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "Sony WH-1000XM5",
                    ImageURL = "https://images.unsplash.com/photo-1546435770-a3e426bf472b?w=600&auto=format&fit=crop&q=60",
                    ProductPrice = 7490000m,
                    Description = "Tai nghe chống ồn không dây hàng đầu Sony WH-1000XM5 - Âm thanh Hi-Res, chống ồn thông minh."
                },
                new Product
                {
                    ProductID = 6,
                    ProductName = "iPad Air 6 M2",
                    ImageURL = "https://images.unsplash.com/photo-1544244015-0df4b3ffc6b0?w=600&auto=format&fit=crop&q=60",
                    ProductPrice = 16990000m,
                    Description = "Máy tính bảng iPad Air thế hệ mới với chip Apple M2 - Thiết kế mỏng nhẹ, hỗ trợ Apple Pencil Pro."
                },
                new Product
                {
                    ProductID = 7,
                    ProductName = "Apple Watch Ultra 2",
                    ImageURL = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=600&auto=format&fit=crop&q=60",
                    ProductPrice = 21490000m,
                    Description = "Đồng hồ thông minh thể thao chuyên nghiệp vỏ Titan bền bỉ, màn hình 3000 nits siêu sáng."
                },
                new Product
                {
                    ProductID = 8,
                    ProductName = "Bàn phím cơ Keychron Q1 Pro",
                    ImageURL = "https://images.unsplash.com/photo-1587829741301-dc798b83add3?w=600&auto=format&fit=crop&q=60",
                    ProductPrice = 4200000m,
                    Description = "Bàn phím cơ Custom không dây khung nhôm CNC, kết nối Bluetooth & Type-C, gõ siêu êm."
                },
                new Product
                {
                    ProductID = 9,
                    ProductName = "Chuột Logitech MX Master 3S",
                    ImageURL = "https://images.unsplash.com/photo-1615663245857-ac93bb7c39e7?w=600&auto=format&fit=crop&q=60",
                    ProductPrice = 2390000m,
                    Description = "Chuột công thái học cao cấp cho lập trình viên và sáng tạo nội dung, click yên tĩnh, cuộn siêu tốc."
                },
                new Product
                {
                    ProductID = 10,
                    ProductName = "Màn hình LG UltraFine 27UP850",
                    ImageURL = "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=600&auto=format&fit=crop&q=60",
                    ProductPrice = 8990000m,
                    Description = "Màn hình 27 inch 4K UHD IPS, chuẩn màu DCI-P3 95%, hỗ trợ cổng USB-C sạc 96W cho laptop."
                }
            };
        }
    }
}
