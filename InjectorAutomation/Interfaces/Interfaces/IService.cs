using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface IService
    {
        /// <summary>
        /// 单例注入
        /// </summary>
        /// <typeparam name="TService">单例的接口类型</typeparam>
        /// <param name="serverImpl">单例的实现类</param>
        void InjectionSingleInstance<TService>(object serverImpl);
        /// <summary>
        /// 单例注入
        /// </summary>
        /// <typeparam name="TService">单例的接口类型</typeparam>
        /// <typeparam name="ServiceImpl">单例的实现类</typeparam>
        void InjectionSingleInstance<TService, ServiceImpl>();
        /// <summary>
        /// 单例注入
        /// </summary>
        /// <typeparam name="TService">单例的接口类型</typeparam>
        /// <param name="func">返回TService的实例</param>
        void InjectionSingleInstance<TService>(Func<TService> func);
        /// <summary>
        /// 注入类型
        /// </summary>
        /// <typeparam name="TService">注入的接口类型</typeparam>
        /// <typeparam name="ServiceImpl">接口的实现类</typeparam>
        void InjectionType<TService, ServiceImpl>();
        /// <summary>
        /// 注入类型
        /// </summary>
        /// <typeparam name="TService">注入的接口类型</typeparam>
        /// <param name="func">每次注入创建实例的时候所需要的创建过程</param>
        void InjectionType<TService>(Func<TService> func);

        /// <summary>
        /// 获取容器中的对象实例
        /// </summary>
        /// <typeparam name="T">对象接口类型</typeparam>
        /// <returns>对象实例</returns>
        T Resolve<T>();
        /// <summary>
        /// 启动容器
        /// </summary>
        void Start();
    }
}
