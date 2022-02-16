// WiX Toolset Pills 15mg
// Copyright (C) 2019-2022 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Security.Principal;
using Microsoft.Deployment.WindowsInstaller;

namespace DustInTheWind.ImpersonateUser.CustomActions
{
    public class LogUserInfoCustomAction
    {

        // ====================================================================================================
        // Step 2: Implement the custom action
        // ====================================================================================================
        // 
        // Retrieve the roles for the current user and write them into the log.
        // 
        // NEXT: Product.wxs

        [CustomAction("LogUserInfo")]
        public static ActionResult Execute(Session session)
        {
            session.Log("--> Begin LogUserInfo custom action");
            try
            {
                using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
                {
                    UserRoles userRoles = new UserRoles(identity);
                    session.Log("Current user roles: " + Environment.NewLine + userRoles);

                    return ActionResult.Success;
                }
            }
            catch (Exception ex)
            {
                session.Log("ERROR: " + ex);
                return ActionResult.Failure;
            }
            finally
            {
                session.Log("--> End LogUserInfo custom action");
            }
        }
    }
}