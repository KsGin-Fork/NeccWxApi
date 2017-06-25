﻿namespace NeccWxApi.Models
{
    /// <summary>
    /// 分数查询模型
    /// </summary>
    public class QScoreParModel
    {
        /// <summary>
        /// 科类
        /// </summary>
        public string classes { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public int year { get; set; }
        /// <summary>
        /// 分数下限
        /// </summary>
        public int lScore { get; set; }
        /// <summary>
        /// 分数上限
        /// </summary>
        public int rScore { get; set; }
        /// <summary>
        /// 学校所在地
        /// </summary>
        public string uniLocal { get; set; }
        /// <summary>
        /// 专业批次
        /// </summary>
        public string batch { get; set; }
    }

    /// <summary>
    /// 位次查询模型
    /// </summary>
    public class QPNumParModel
    {
        /// <summary>
        /// 科类
        /// </summary>
        public string classes { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public int year { get; set; }
        /// <summary>
        /// 位次下限
        /// </summary>
        public int lPNum { get; set; }
        /// <summary>
        /// 位次上限
        /// </summary>
        public int rPNum { get; set; }
        /// <summary>
        /// 学校所在地
        /// </summary>
        public string uniLocal { get; set; }
        /// <summary>
        /// 专业批次
        /// </summary>
        public string batch { get; set; }
    }
}