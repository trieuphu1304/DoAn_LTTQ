using System;
using System.Collections.Generic;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ
{
    /// <summary>
    /// Quản lý trạng thái đơn hàng cho từng bàn
    /// </summary>
    public class TableStateManager
    {
        private static TableStateManager instance = null;
        private Dictionary<int, List<BillInfo>> tableOrders = new Dictionary<int, List<BillInfo>>();
        private Dictionary<int, bool> tableOrderConfirmed = new Dictionary<int, bool>();

        private TableStateManager()
        {
        }

        public static TableStateManager GetInstance()
        {
            if (instance == null)
            {
                instance = new TableStateManager();
            }
            return instance;
        }

        /// <summary>
        /// Lấy danh sách đơn hàng của một bàn
        /// </summary>
        public List<BillInfo> GetTableOrders(int tableId)
        {
            if (!tableOrders.ContainsKey(tableId))
            {
                tableOrders[tableId] = new List<BillInfo>();
            }
            return tableOrders[tableId];
        }

        /// <summary>
        /// Thêm một bàn vào hệ thống quản lý
        /// </summary>
        public void InitializeTable(int tableId)
        {
            if (!tableOrders.ContainsKey(tableId))
            {
                tableOrders[tableId] = new List<BillInfo>();
                tableOrderConfirmed[tableId] = false;
            }
        }

        /// <summary>
        /// Xóa đơn hàng của một bàn (sau khi thanh toán)
        /// </summary>
        public void ClearTableOrders(int tableId)
        {
            if (tableOrders.ContainsKey(tableId))
            {
                tableOrders[tableId].Clear();
                tableOrderConfirmed[tableId] = false;
            }
        }

        /// <summary>
        /// Kiểm tra xem đơn hàng của bàn đã được xác nhận chưa
        /// </summary>
        public bool IsOrderConfirmed(int tableId)
        {
            if (!tableOrderConfirmed.ContainsKey(tableId))
            {
                tableOrderConfirmed[tableId] = false;
            }
            return tableOrderConfirmed[tableId];
        }

        /// <summary>
        /// Đánh dấu đơn hàng của bàn đã được xác nhận
        /// </summary>
        public void SetOrderConfirmed(int tableId, bool confirmed)
        {
            tableOrderConfirmed[tableId] = confirmed;
        }

        /// <summary>
        /// Xóa toàn bộ dữ liệu (khi khởi động lại)
        /// </summary>
        public void ClearAll()
        {
            tableOrders.Clear();
            tableOrderConfirmed.Clear();
        }
    }
}
