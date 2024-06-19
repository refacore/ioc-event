# Events
Repo này sẽ minh họa ba cách để xây dựng bộ xử lý Event (bằng C#)

## event của C#
Khai báo event và event theo cách mà C# cung cấp. Đây là một chức năng tuyệt vời có sẵn. Nhưng cũng có một số rắc rối khi sử dụng:
- Là chức năng của riêng C#, trong các sản phẩm sử dụng nhiều tech stack, dùng thứ gì đó quá đặc trưng thì tăng dung lượng knowledge base của team, có chút phiền toái khi bảo trì.
- Không thân thiện với async/await.
- Chỉ xử lý tuần tự.
- Vì 2 gạch trên, handler xử lý quá lâu có thể ảnh hưởng đến hệ thống.
- Chỉ stack với hàm. delegate của C# có nguồn gốc từ con trỏ hàm, di sản từ C++. C# được thiết kế ban đầu là ngôn ngữ hướng đối tượng hoàn toàn (bây giờ thì là general purpose), delegate có vẻ hơi lệch tông.
- Có thể đăng ký handler ở bất cứ đâu, bất cứ khi nào. Việc handler nào chạy trước, chạy sau là khó đoán trước. Không khéo mà để lệnh đăng kí rơi vào vòng lặp thì rất khủng khiếp.
- Một số trường hợp có thể không xóa delegate được (ví dụ như trong mã nguồn này, chúng ta sử dụng lambda để thêm handler. Làm sao để loại bỏ nó?).

## Observer pattern
Có các tên gọi khác như pub/sub, Event Emitter và được ứng dụng rộng rãi. Dễ thấy nhất là hệ thống event của javascript.
Chắc chắn đây là một pattern hữu dụng tuyệt vời. Không có gì để phàn nàn về nó. Bạn có đầy đủ khả năng điều khiển, tùy biến, theo ý bạn. Nó không chỉ được sử dụng trong OOP mà trong tất cả các mô típ lập trình khác. Nói thế không phải nó không có điểm yếu:
- \[COPIED\] Có thể subcribe ở bất cứ đâu, bất cứ khi nào. Việc handler nào chạy trước, chạy sau là khó đoán trước. Không khéo mà để lệnh đăng kí rơi vào vòng lặp thì rất khủng khiếp.
- Publisher quản lý một danh sách các subscriber (object). Các subscriber này có thể thay đổi hành vi trong runtime. Đây là con dao hai lưỡi.
- Việc Unsubscribe có thể phức tạp và khó khăn trong một số trường hợp. Nếu không thể unsub, hệ thống chạy thời gian dài có thể bị chậm, leak bộ nhớ, danh sách subscriber không được thu dọn.

## Event dispatcher dùng DI
Về cơ bản, EventDispatcher là một biến thể của Observer. Cái khác là Dispatcher không quản lý danh sách subscriber. Các subscriber này được đăng ký qua DI container. Hệ quả là gì?
- Khó để đăng ký subscriber tùy tiện. Nói chung chỉ đăng ký 1 lần và không thay đổi trong runtime.
- Khó để unsubscribe. Chúng ta cũng không nên cố đấm ăn xôi làm gì. Việc sub và unsub khắp nơi vẫn có thể thực hiện, nhưng đặc tính của DI là có độ trễ. Việc thực hiện sub, unsub có thể gây lỗi runtime rất đau đầu.
- Những điểm tiết chế trên để giúp EventDispatcher an toàn hơn, được quản lý tốt hơn.
- Việc sử dụng type của event như dấu hiệu nhận biết handler cũng rất tuyệt. Rõ ràng, duyên dáng hơn Observer cổ điển (chúng ta phải tạo nhiều Publisher cho từng loại event, hoặc tự quản lý event type - topic trong một Publisher duy nhất).
---
Mỗi cách đều có ưu nhược điểm. Cá nhân tôi thì thiên về Observer và EventDispatcher hơn. Khi danh sách subscriber là cố định tại runtime thì ưu tiên dùng EventDispatcher.