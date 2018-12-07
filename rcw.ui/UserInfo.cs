using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DevExpress.XtraEditors.Repository;
using Rcw.Model;

namespace Rcw.UI
{
    public class UserInfo
    {
        private static string userID;//用户ID
        /// <summary>
        /// 用户id 流水号
        /// </summary>
        public static string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private static string userAccount; //用户账号
        /// <summary>
        /// 用户账号
        /// </summary>
        public static string UserAccount
        {
            get { return userAccount; }
            set { userAccount = value; }
        }

        private static string userName; //用户名
        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public static string menuName;//菜单名
        public static string MenuName
        {
            get { return menuName; }
            set { menuName = value; }
        }

        /// <summary>
        /// 用户的所有权限
        /// </summary>
        public static List<TS_MODULE> UserResouce
        {
            get; set;
        }
        /// <summary>
        /// 用户的菜单权限
        /// </summary>
        public static List<TS_MODULE> UserMenu
        {
            get;set;
        }
        /// <summary>
        /// 用户的按钮权限
        /// </summary>
        public static List<TS_MODULE> UserBtn
        {
            get; set;
        }

    }
}
