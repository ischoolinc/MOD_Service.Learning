using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;
using System.Xml.Linq;

namespace K12.Service.Learning.CreationItems
{
    [TableName("K12.Service.Learning.CreationItemsRecord")]
    public class CreationItemsRecord : ActiveRecord//, System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// 報名開始時間
        /// </summary>
        [Field(Field = "regist_start_time", Indexed = false)]
        public DateTime RegistStartTime { get; set; }
        /// <summary>
        /// 報名結束時間
        /// </summary>
        [Field(Field = "regist_end_time", Indexed = false)]
        public DateTime RegistEndTime { get; set; }
        /// <summary>
        /// 學年度
        /// </summary>
        [Field(Field = "school_year", Indexed = false)]
        public int SchoolYear { get; set; }
        /// <summary>
        /// 學期
        /// </summary>
        [Field(Field = "semester", Indexed = false)]
        public int Semester { get; set; }
        /// <summary>
        /// 主辦單位
        /// </summary>
        [Field(Field = "organizers", Indexed = false)]
        public string Organizers { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        [Field(Field = "occur_date", Indexed = false)]
        public DateTime OccurDate { get; set; }
        /// <summary>
        /// 地點
        /// </summary>
        [Field(Field = "location", Indexed = false)]
        public string Location { get; set; }
        /// <summary>
        /// 預計時數
        /// </summary>
        [Field(Field = "expected_hours", Indexed = false)]
        public decimal ExpectedHours { get; set; }
        /// <summary>
        /// 服務事由
        /// </summary>
        [Field(Field = "reason", Indexed = false)]
        public string Reason { get; set; }
        /// <summary>
        /// 人數上限
        /// </summary>
        [Field(Field = "participate_limit", Indexed = false)]
        public int ParticipateLimit { get; set; }
        /// <summary>
        /// 開設人帳號
        /// </summary>
        [Field(Field = "create_by", Indexed = false)]
        public string CreateBy { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        [Field(Field = "remark", Indexed = false)]
        public string Remark { get; set; }
        [Field(Field = "extension", Indexed = false)]
        public string Extension { get; set; }

        // 儲存於Extension
        private XElement _xe ;
        public XElement ApprovedDetail
        {
            get { return (XElement)getter("ApprovedDetail", TypeCode.Object); }
            set { setter("ApprovedDetail", TypeCode.Object, value); }
        }
        public bool IsAuthorized
        {
            get { return (bool)getter("IsAuthorized",TypeCode.Boolean); }
            set { setter("IsAuthorized", TypeCode.Boolean, value); }
        }
        public string IsAuthorizedText
        {
            get { return (bool)getter("IsAuthorized", TypeCode.Boolean)?"是":""; }
        }
        public string AuthorizedBy
        {
            get { return (string)getter("AuthorizedBy", TypeCode.String); }
            set { setter("AuthorizedBy", TypeCode.String, value); }
        }
        public DateTime AuthorizedAt
        {
            get { return (DateTime)getter("AuthorizedAt", TypeCode.DateTime); }
            set { setter("AuthorizedAt", TypeCode.DateTime, value); }
        }
        public bool IsApproved
        {
            get { return (bool)getter("IsApproved", TypeCode.Boolean); }
            set { setter("IsApproved", TypeCode.Boolean, value); }
        }
        public string IsApprovedText
        {
            get { return (bool)getter("IsApproved", TypeCode.Boolean)?"是":""; }
        }
        public string ApprovedBy
        {
            get { return (string)getter("ApprovedBy", TypeCode.String); }
            set { setter("ApprovedBy", TypeCode.String, value); }
        }
        public DateTime ApprovedAt
        {
            get { return (DateTime)getter("ApprovedAt", TypeCode.DateTime); }
            set { setter("ApprovedAt", TypeCode.DateTime, value); }
        }

        private object getter(string field, TypeCode tc)
        {
            if (_xe == null && !string.IsNullOrWhiteSpace(this.Extension))
                _xe = XElement.Parse(this.Extension);
            if (_xe == null)
                _xe = new XElement("Extension");
            if ( _xe.Element(field) == null)
            {
                switch (tc)
                {
                    case TypeCode.Boolean:
                        return false;
                    case TypeCode.DateTime:
                        return new DateTime();
                    case TypeCode.String:
                        return string.Empty;
                    case TypeCode.Object:
                        XElement tmpxe = new XElement(field);
                        _xe.Add(tmpxe);
                        return tmpxe;
                    default:
                        return null;
                }
            }
            switch (tc)
            {
                case TypeCode.Boolean:
                    return _xe.Element(field).Value == "True";
                case TypeCode.DateTime:
                    return DateTime.Parse(_xe.Element(field).Value);
                case TypeCode.String:
                    return _xe.Element(field).Value;
                case TypeCode.Object: 
                    //return XElement
                    return _xe.Element(field);
                default:
                    return null;
            }
        }
        private void setter(string field,TypeCode tc, object value)
        {
            if (_xe == null && !string.IsNullOrWhiteSpace(this.Extension))
                _xe = XElement.Parse(this.Extension);
            if (_xe == null)
                _xe = new XElement("Extension");
            if (_xe.Element(field) == null)
                _xe.Add(new XElement(field));
            switch (tc)
            {
                case TypeCode.Boolean:
                    _xe.Element(field).Value = (bool)value ? "True" : "False";
                    break;
                case TypeCode.DateTime:
                    _xe.Element(field).Value = ((DateTime)value).ToString("yyyy/MM/dd HH:mm:ss");
                    break;
                case TypeCode.String:
                    _xe.Element(field).Value = (string)value;
                    break;
                case TypeCode.Object:
                    //_xe.Element(field).RemoveAttributes();
                    //_xe.Add(value);
                    break;
                default:
                    break;
            }
            this.Extension = _xe.ToString(SaveOptions.DisableFormatting);
        }
        //public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
