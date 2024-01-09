using StoreManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement
{
    public partial class Goods
    {
        public string GoodsTypeName
        {
            get
            {
                string name = string.Empty;

                GoodsType model = new GoodsTypeService().Select().FirstOrDefault(t => t.Id == GoodsTypeId);
                if (model != null)
                    return model.Name;
                else
                    return name;
            }
        }
        public string SpecName
        {
            get
            {
                string name = string.Empty;

                Spec model = new SpecService().Select().FirstOrDefault(t => t.Id == SpecId);
                if (model != null)
                    return model.Name;
                else
                    return name;
            }
        }

    }
}
