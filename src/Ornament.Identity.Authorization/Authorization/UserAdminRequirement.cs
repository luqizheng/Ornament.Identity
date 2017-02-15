namespace Ornament.Identity.Authorization
{
    public enum UserManageOperator
    {
        None = 0,
        Read = 1,
        Create = 2 | Read,
        Sensitive = 4,
        Update = 8 | Read,
        Delete = 16 | Sensitive | Update
    }

    public enum RoleManageOperator
    {
        None = 0,
        Read = 1,
        Update = 2 | Read,
        ChangeKeyName = 4 | Update,
        Delete = 8 | ChangeKeyName
    }

    public class UserManageRequirement : EnumOperationAuthorizationRequirement<UserManageOperator>
    {
        public const string PolicyName = "UserManage";

        public static UserManageRequirement Create =
            new UserManageRequirement {Name = "Create", Operator = UserManageOperator.Create};

        public static UserManageRequirement Read =
            new UserManageRequirement {Name = "Read", Operator = UserManageOperator.Read};


        public static UserManageRequirement Sensitive =
            new UserManageRequirement {Name = "Sensitive", Operator = UserManageOperator.Sensitive};

        public static UserManageRequirement Update =
            new UserManageRequirement {Name = "Update", Operator = UserManageOperator.Update};

        public static UserManageRequirement Delete =
            new UserManageRequirement {Name = "Delete", Operator = UserManageOperator.Delete};

        public string Name { get; set; }
    }

    public class RoleManageRequirement : EnumOperationAuthorizationRequirement<RoleManageOperator>
    {
        public const string PolicyName = "RoleManage";

        public static RoleManageRequirement Create =
            new RoleManageRequirement
            {
                Name = "ChangeKeyName",
                Operator = RoleManageOperator.ChangeKeyName
            };

        public static RoleManageRequirement Read =
            new RoleManageRequirement {Name = "Read", Operator = RoleManageOperator.Read};


        public static RoleManageRequirement Update =
            new RoleManageRequirement {Name = "Update", Operator = RoleManageOperator.Update};

        public static RoleManageRequirement Delete =
            new RoleManageRequirement {Name = "Delete", Operator = RoleManageOperator.Delete};

        public string Name { get; set; }
    }
}