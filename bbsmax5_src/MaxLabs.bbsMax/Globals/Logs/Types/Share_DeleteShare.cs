﻿//
// 请注意：bbsmax 不是一个免费产品，源代码仅限用于学习，禁止用于商业站点或者其他商业用途
// 如果您要将bbsmax用于商业用途，需要从官方购买商业授权，得到授权后可以基于源代码二次开发
//
// 版权所有 厦门麦斯网络科技有限公司
// 公司网站 www.bbsmax.com
//

using System;
using System.Collections.Generic;
using System.Text;

namespace MaxLabs.bbsMax.Logs
{
	[OperationType(Share_DeleteShare.TYPE_NAME, "分享ID", "作者ID")]
	public class Share_DeleteShare : Operation
	{
        public const string TYPE_NAME = "删除分享";

		public Share_DeleteShare(int operatorID, string operatorName, string operatorIP, int shareID, int shareOwnerID, string shareOwnerName, string shareContent)
			: base(operatorID, operatorName, operatorIP, shareID, shareOwnerID)
		{
			ShareOwnerName = shareOwnerName;
			ShareContent = shareContent;
		}

        public override string TypeName
        {
            get { return TYPE_NAME; }
        }

		public string ShareOwnerName
		{
			get;
			private set;
		}

		public string ShareContent
		{
			get;
			private set;
		}

		public override string Message
		{
			get
			{

				return string.Format(
					"<a href=\"{0}\">{1}</a> 删除了{3}的分享：“{2}”"
					, BbsRouter.GetUrl("space/" + OperatorID)
					, OperatorName
					, ShareContent
					, OperatorID == TargetID_2 ? "自己" : string.Format("用户 <a href=\"{0}\">{1}</a> ", BbsRouter.GetUrl("space/" + TargetID_2), ShareOwnerName)
				);
			}
		}
	}
}