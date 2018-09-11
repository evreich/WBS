using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Descriptors.ConstantModelFields
{
    public class ProfileForm
    {
        public (string label, string name) FIO { get; private set; }
        public (string label, string name) JobPosition { get; private set; }
        public (string label, string name) Department { get; private set; }
        public (string label, string name) DeletionMark { get; private set; }
        public (string label, string name) Login { get; private set; }
        public (string label, string name) Password { get; private set; }
        public (string label, string name) Roles { get; private set; }

        public ProfileForm()
        {
            FIO = ("ФИО", "fio");
            JobPosition = ("Должность", "jobPosition");
            Department = ("Подразделение", "department");
            DeletionMark = ("Помечено на удаление", "deletionMark");
            Login = ("Логин", "login");
            Password = ("Пароль", "password");
            Roles = ("Полномочия", "roles");
        }
    }
}
