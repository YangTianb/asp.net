/**
 * Created by pc-hp on 2016/3/8.
 */

// 声明 User 构造器
function User(pwd) {
    // 定义私有属性
    var password = pwd;
    // 定义私有方法
    function getPassword() {
        // 返回了闭包中的 password
        return password;
    }
    // 特权函数声明，用于该对象其他公有方法能通过该特权方法访问到私有成员
    this.passwordService = function() {
        return getPassword();
    }
}
// 公有成员声明
User.prototype.checkPassword = function(pwd) {
    return this.passwordService() === pwd;
};
