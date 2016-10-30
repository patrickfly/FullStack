﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class UserNotification
    {

        public UserNotification(ApplicationUser user, Notification notification)
        {
            if(user == null)
                throw new ArgumentNullException("user");
            if(notification == null)
                throw new ArgumentNullException("notification");
            User = user;
            Notification = notification;
        }

        /// <summary>
        /// 必须创建一个空构造函数，因为EF不能使用有参构造函数
        /// </summary>
        protected UserNotification()
        {
            
        }

        [Key]
        [Column(Order = 1)]
        public string UserId { get; private set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; private set; }


        //不能为空，所以使用构造函数赋值
        //不能被修改，所以使用private set
        public ApplicationUser User { get; private set; }
        public Notification Notification { get; private set; }

        public bool IsRead { get; private set; }

        public void Read()
        {
            IsRead = true;
        }
    }
}