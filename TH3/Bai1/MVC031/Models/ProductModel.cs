namespace MVC031.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    public class ProductModel
    {
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Laptop Dell XPS 13",
                    ProductPrice = 28500000,
                    ImageURL = "https://images.unsplash.com/photo-1593642632823-8f785ba67e45?w=500&auto=format&fit=crop&q=60",
                    Description = "Laptop siêu mỏng nhẹ, vi xử lý Intel Core i7, màn hình 4K viền siêu mỏng InfinityEdge."
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "iPhone 15 Pro Max",
                    ProductPrice = 31990000,
                    ImageURL = "https://images.unsplash.com/photo-1695048133142-1a20484d2569?w=500&auto=format&fit=crop&q=60",
                    Description = "Khung viền titan siêu nhẹ, chip A17 Pro mạnh mẽ, camera tiềm vọng zoom quang học 5x."
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Bàn phím cơ Keychron K2",
                    ProductPrice = 1850000,
                    ImageURL = "https://images.unsplash.com/photo-1587829741301-dc798b83add3?w=500&auto=format&fit=crop&q=60",
                    Description = "Bàn phím cơ Bluetooth layout 75%, đèn nền RGB, hỗ trợ chuyển đổi nhanh giữa Mac và Windows."
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Chuột Logitech MX Master 3S",
                    ProductPrice = 2250000,
                    ImageURL = "https://images.unsplash.com/photo-1615663245857-ac93bb7c39e7?w=500&auto=format&fit=crop&q=60",
                    Description = "Chuột công thái học cao cấp cho lập trình viên, bánh lăn siêu tốc MagSpeed, click êm ái."
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "Tai nghe Sony WH-1000XM5",
                    ProductPrice = 7290000,
                    ImageURL = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500&auto=format&fit=crop&q=60",
                    Description = "Tai nghe chống ồn đỉnh cao hàng đầu thế giới, âm thanh Hi-Res chân thực, pin 30 giờ."
                },
                new Product
                {
                    ProductID = 6,
                    ProductName = "Màn hình Dell UltraSharp 27 inch",
                    ProductPrice = 9800000,
                    ImageURL = "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=500&auto=format&fit=crop&q=60",
                    Description = "Màn hình đồ họa chuẩn màu 4K IPS, hỗ trợ cổng kết nối USB-C sạc ngược tiện lợi."
                },
                new Product
                {
                    ProductID = 7,
                    ProductName = "Apple Watch Series 9",
                    ProductPrice = 9990000,
                    ImageURL = "https://images.unsplash.com/photo-1508685096489-7aacd43bd3b1?w=500&auto=format&fit=crop&q=60",
                    Description = "Đồng hồ thông minh cảm ứng cử chỉ Double Tap, đo nhịp tim và theo dõi giấc ngủ chuẩn xác."
                },
                new Product
                {
                    ProductID = 8,
                    ProductName = "iPad Air 5 M1",
                    ProductPrice = 14900000,
                    ImageURL = "https://images.unsplash.com/photo-1544244015-0df4b3ffc6b0?w=500&auto=format&fit=crop&q=60",
                    Description = "Hiệu năng bứt phá với chip M1, màn hình Liquid Retina sắc nét, tương thích Apple Pencil 2."
                },
                new Product
                {
                    ProductID = 9,
                    ProductName = "Loa Bluetooth Marshall Acton III",
                    ProductPrice = 5990000,
                    ImageURL = "https://images.unsplash.com/photo-1545454675-3531b543be5d?w=500&auto=format&fit=crop&q=60",
                    Description = "Âm trường rộng hơn thế hệ trước, thiết kế cổ điển sang trọng, chất âm mộc mạc tinh tế."
                },
                new Product
                {
                    ProductID = 10,
                    ProductName = "Ổ cứng SSD di động Samsung T7 1TB",
                    ProductPrice = 2750000,
                    ImageURL = "https://images.unsplash.com/photo-1597872200969-2b65d56bd16b?w=500&auto=format&fit=crop&q=60",
                    Description = "Tốc độ truyền dữ liệu lên tới 1050 MB/s, vỏ nhôm chống sốc và rơi vỡ an toàn tuyệt đối."
                }
            };
        }
    }
}
