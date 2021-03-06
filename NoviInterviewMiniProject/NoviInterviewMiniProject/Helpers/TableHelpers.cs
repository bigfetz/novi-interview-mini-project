﻿using NoviInterviewMiniProject.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace NoviInterviewMiniProject.Helpers
{
    public static class TableHelpers
    {
        /// <summary>
        /// Generates a html header link to work with table sorting and include other table property state values. 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="controller"></param>
        /// <param name="tableModel"></param>
        /// <returns></returns>
        public static IHtmlString Header(this HtmlHelper helper, string name, string controller, TableModel tableModel)
        {
            var sortOnCondensed = name.Replace(" ", "").ToUpper();
            bool isAsc = tableModel.SortOn == sortOnCondensed ? !tableModel.IsAsc : tableModel.IsAsc;
            string sortCarrot = tableModel.SortOn == sortOnCondensed ?
                (tableModel.IsAsc ? "<span class='glyphicon glyphicon-chevron-up' aria-hidden='true'></span>"
                : "<span class='glyphicon glyphicon-chevron-down' aria-hidden='true'></span>") : "";
            return MvcHtmlString.Create(String.Format("<a href='/{0}/Index?sorton={1}&isAsc={2}&search={3}'>{4}{5}</a>", controller, sortOnCondensed, isAsc, tableModel.Search, name, sortCarrot));
        }
    }
}