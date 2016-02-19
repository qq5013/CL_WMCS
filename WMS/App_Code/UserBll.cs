﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using IServices;
using Util;
using System.Data;


namespace BLL.Security
{
    public class UserBll
    {
        private Dictionary<string, object> Channels = new Dictionary<string, object>();

        private IServices.Security.ISecurityService bll;

        public UserBll()
        {
            bll = GetChannel<IServices.Security.ISecurityService>();
            bll.SetCnKey("");
        }
        public UserBll(string CnKey)
        {
            bll = GetChannel<IServices.Security.ISecurityService>();
            bll.SetCnKey(CnKey);
        }

        private TChannel GetChannel<TChannel>()
        {
            try
            {
                string endPointConfigName = typeof(TChannel).Name;
                if (Channels.ContainsKey(endPointConfigName))
                {
                    return (TChannel)Channels[endPointConfigName];
                }

                ChannelFactory<TChannel> channelFactory = new ChannelFactory<TChannel>(endPointConfigName);
                TChannel channel = channelFactory.CreateChannel();
                Channels.Add(endPointConfigName, channel);
                return channel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetUserInfo(string UserName)
        {

            return bll.GetUserInfo(UserName);
        }
        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PWD"></param>
        public void UpdateUserPWD(string UserName, string PWD)
        {
            bll.UpdateUserPWD(UserName, PWD);

        }
        public DataTable GetUserList(int pageIndex, int pageSize, string filter, string OrderByFields)
        {
            return bll.GetUserList(pageIndex, pageSize, filter, OrderByFields);

        }
        public void InsertUser(string UserName, string EmployeeCode, string Memo)
        {
            bll.InsertUser(UserName, EmployeeCode, Memo);

        }
        public void UpdateUser(string UserName, string EmployeeCode, string Memo, int UserID)
        {
            bll.UpdateUser(UserName, EmployeeCode, Memo, UserID);

        }

        public bool Login(string UserName, string Pwd)
        {
            return bll.Login(UserName, Pwd);

        }




    }
}




