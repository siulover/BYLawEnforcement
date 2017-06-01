﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    /// <summary>
    /// 组织机构
    /// </summary>
    public class Orgnizations
    {
        /// <summary>
        /// 组织机构编号
        /// </summary>
        [Required]
        public string OrgNo { get; set; }
        /// <summary>
        /// 组织机构名字
        /// </summary>
        public string OrgName { get; set; }
        /// <summary>
        /// 组织机构的职责
        /// </summary>
        public string OrgDuty { get; set; }
        /// <summary>
        /// 组织机构描述
        /// </summary>
        public string OrgDes { get; set; }
        /// <summary>
        /// 上级组织机构编号 
        /// </summary>
        public string UpOrgNo { get; set; }

        public int OrgFlag { get; set; }
    }
}
