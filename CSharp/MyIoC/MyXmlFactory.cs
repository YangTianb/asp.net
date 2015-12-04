using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyIoC
{
    public class MyXmlFactory
    {
        private IDictionary<string, object> objectDefine = new Dictionary<string, object>();

        public MyXmlFactory(string fileName)
        {
            InstanceObjects(fileName);  // 实例IoC容器
        }

        /// <summary>
        /// 实例IoC容器
        /// </summary>
        /// <param name="fileName"></param>
        private void InstanceObjects(string fileName)
        {
            XElement root = XElement.Load(fileName);
            var objects = from obj in root.Elements("object") select obj;
            objectDefine = objects.ToDictionary(
                    k => k.Attribute("id").Value,
                    v =>
                    {
                        string typeName = v.Attribute("type").Value;
                        Type type = Type.GetType(typeName);
                        return Activator.CreateInstance(type);
                    }
                );
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetObject(string id)
        {
            object result = null;

            if (objectDefine.ContainsKey(id))
            {
                result = objectDefine[id];
            }

            return result;
        }
    }
}
