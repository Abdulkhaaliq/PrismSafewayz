﻿using ProjectSafeWayz.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSafeWayz.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public int MenuOrder { get; set; }
        public string MenuItemName { get; set; }
        public string NavigationPath { get; set; }
        public MenuTypeEnum MenuType { get; set; }
    }
}
