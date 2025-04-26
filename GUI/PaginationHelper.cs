using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public static class PaginationHelper
    {
        public static void GeneratePaginationButtons(
            Panel pnlPagination,
            int currentPage,
            int totalPages,
            Action<int> loadPageAction)
        {
            pnlPagination.Controls.Clear();

            int maxPageButtons = 5;
            int startPage = Math.Max(1, currentPage - 2);
            int endPage = Math.Min(totalPages, startPage + maxPageButtons - 1);

            if (endPage - startPage + 1 < maxPageButtons)
            {
                startPage = Math.Max(1, endPage - maxPageButtons + 1);
            }

            // Nút "Đầu Trang"
            if (currentPage > 1)
            {
                pnlPagination.Controls.Add(CreateGunaButton("<<", (s, e) => loadPageAction(1)));
            }

            // Nút "Trang trước"
            if (currentPage > 1)
            {
                pnlPagination.Controls.Add(CreateGunaButton("<", (s, e) => loadPageAction(currentPage - 1)));
            }

            // Các nút số trang
            for (int i = startPage; i <= endPage; i++)
            {
                int selectedPage = i;
                pnlPagination.Controls.Add(CreateGunaButton(i.ToString(), (s, e) => loadPageAction(selectedPage), i == currentPage));
            }

            // Nút "Trang sau"
            if (currentPage < totalPages)
            {
                pnlPagination.Controls.Add(CreateGunaButton(">", (s, e) => loadPageAction(currentPage + 1)));
            }

            // Nút "Cuối Trang"
            if (currentPage < totalPages)
            {
                pnlPagination.Controls.Add(CreateGunaButton(">>", (s, e) => loadPageAction(totalPages)));
            }
        }

        private static Guna2Button CreateGunaButton(string text, EventHandler onClick, bool isActive = false)
        {
            int width = (text == ">>" || text == "<<") ? 60 : 45;

            var btn = new Guna2Button
            {
                Text = text,
                Width = width,
                Height = 32,
                BorderRadius = 6,
                FillColor = isActive ? Color.DodgerBlue : Color.Gainsboro,
                ForeColor = isActive ? Color.White : Color.Black,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Margin = new Padding(4),
                Cursor = Cursors.Hand,
                TextAlign = HorizontalAlignment.Center,
                Padding = new Padding(0)
            };
            btn.Click += onClick;
            return btn;
        }
    }

