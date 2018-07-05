using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ResutEntity<T> where T : new()
    {
        private List<T> _data = null;
        private T _model;
        /// <summary>
        /// 状态-默认返回不正常状态
        /// </summary>
        private int _status = -1;
        public int Status { get { return _status; } set { _status = value; } }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public List<T> Data
        {
            get
            {
                return _data;
            }
            set { _data = value; }
        }
    }

    public class ResutEntity
    {
        /// <summary>
        /// 状态-默认返回不正常状态
        /// </summary>
        private int _status = -1;
        public int Status { get { return _status; } set { _status = value; } }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
    }
}
