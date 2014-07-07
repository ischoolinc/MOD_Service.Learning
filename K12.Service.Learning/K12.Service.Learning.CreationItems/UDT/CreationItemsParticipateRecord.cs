using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;
using System.Xml.Linq;

namespace K12.Service.Learning.CreationItems
{
    [TableName("k12.service.learning.creationitemsparticipaterecord")]
    public class CreationItemsParticipateRecord : ActiveRecord
    {
        /// <summary>
        /// 關聯學生id
        /// </summary>
        [Field(Field = "ref_student_id", Indexed = true)]
        public string RefStudentId { get; set; }
        /// <summary>
        /// 關聯開設項目id
        /// </summary>
        [Field(Field = "ref_creationitemsrecord_id", Indexed = true)]
        public string RefCreationItemsRecordId { get; set; }
        /// <summary>
        /// 可參加(核可)
        /// </summary>
        [Field(Field = "can_participate", Indexed = false)]
        public Boolean CanParticipate { get; set; }
        
        /// <summary>
        /// 備註
        /// </summary>
        //[Field(Field = "remark", Indexed = false)]
        //public string Remark { get; set; }
        //[Field(Field = "extension", Indexed = false)]
        //public string Extension { get; set; }
    }
}
