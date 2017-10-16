# XK_Article
##  Article manage system
##  this is a memo 这是一个备忘录
##          本程序目标是实现一个内容管理系统
##        系统基于三层架构+抽象工厂+webform
        
###     以下是关于Factory库的一些备注
        根据传入的T类型动态生成相应的实体产品
        在本程序中ActiveProductGeter相当于一个 抽象工厂，配置文件中指定具体工厂，把判断生成具体工厂的逻辑转移至配置文件中。。。
   
        再通过反射生成具体工厂，具体工厂在本例中 应该相当于是 SqlDAL（也可以是AccessDAL,MySqlDAL,如果有的话！） 整个程序集。。。  
        并非 一般例子中的直接创建并返回 那些与工厂相关产品的类  
        eg : AbstractFactory factorysubA = new AbstractFactoryA();`
     为什么？？？
    
        因为生成产品的方法为一个 泛型方法，生成的产品根据传入的 抽象产品 T（接口)确定，而 T 又通过特性 ImplementFlagAttribute标记  
        了相应的实现类(具体产品), So, 就不用针对每个产品都写一个返回 具体产品的方法。。。
        * 由于判断实体工厂的逻辑在配置文件中，判断具体产品的逻辑在接口特性中，所以本例没有实体工厂类。。。 *
        
      这时你可能还会想问，为什么 不直接 给  T 类型传入SqlDAL的类，这样直接根据类名就可以获取目标产品类，还不用设置特性，增加工作量。  
      因为我想 BLL层 只根 IDAL层联系，如果直接传入具体产品类就得引用SqlDAL,会跟产品库发生联系。
       ![image](http://github.com/WildChocolate/XK_Article/raw/master/ScreenShot/BLL&IDAL.png)
      
