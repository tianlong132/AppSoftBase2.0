using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

/*!
* 文件名称：UserCoreEntity业务场景验证类
* 文件作者：杨龙刚
*/
namespace App.Entity
{
    public class UserCoreEntityValidator : AbstractValidator<UserCoreEntity>
    {
        // 新增验证规则
        public UserCoreEntityValidator()
        {
            // 登录场景验证
            RuleSet("Login", () =>
            {
                RuleFor(user => user.Account).NotNull().NotEmpty().Matches(@"^[\u4E00-\u9FA5\uf900-\ufa2d\w\.\s]{4,32}$", System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace).WithMessage("账号必须是4-32位字符");
                RuleFor(user => user.Password).NotNull().NotEmpty().Matches("[a-zA-Z0-9_]{4,32}", System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace).WithMessage("密码只支持4到32位字母，数字，下划线或组合");
            });

            // 新增或注册场景验证
            RuleSet("Add", () =>
            {
            });
        }
    }
}
