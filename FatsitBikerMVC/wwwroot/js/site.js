// Xử lý chuyển tab tự động dựa trên URL Hash (ví dụ: /#tayga)
document.addEventListener("DOMContentLoaded", function () {
    // 1. Kiểm tra URL khi trang vừa load xong
    activateTabFromHash();

    // 2. Lắng nghe sự kiện khi hash thay đổi (ví dụ người dùng bấm vào menu dropdown khi đang ở trang chủ)
    window.addEventListener("hashchange", activateTabFromHash, false);

    // 3. Xử lý click trên các link dropdown (để tránh cuộn giật cục)
    const dropdownLinks = document.querySelectorAll('.dropdown-item[href^="/#"]');
    dropdownLinks.forEach(link => {
        link.addEventListener('click', function (e) {
            const hash = this.getAttribute('href').replace('/', '');
            
            // Nếu đang ở trang chủ, chỉ cần đổi tab và cuộn mượt xuống
            if (window.location.pathname === '/' || window.location.pathname === '/Home/Index') {
                e.preventDefault();
                window.history.pushState(null, null, hash);
                activateTabFromHash();
            }
            // Nếu ở trang khác, cứ để link hoạt động bình thường để chuyển về trang chủ
        });
    });
});

function activateTabFromHash() {
    let hash = window.location.hash; // Lấy hash từ url, VD: #tayga
    
    if (hash) {
        // ID của nút Tab thường là id-tab, ví dụ #tayga-tab
        let tabId = hash.replace('#', '') + '-tab';
        let tabElement = document.getElementById(tabId);
        
        if (tabElement) {
            // Sử dụng Bootstrap Tab API để hiển thị tab
            let bsTab = new bootstrap.Tab(tabElement);
            bsTab.show();

            // Cuộn mượt xuống khu vực sản phẩm
            let productsSection = document.getElementById('products');
            if (productsSection) {
                productsSection.scrollIntoView({ behavior: 'smooth', block: 'start' });
            }
        }
    }
}
