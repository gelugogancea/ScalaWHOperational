using System;
using System.Text;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Security;
using Microsoft.Win32;
namespace GoWHMgmAdmin
{
    public enum ERegistryPossibleRoots
    {
        HKEY_CLASSES_ROOT = 0,
        HKEY_CURRENT_CONFIG = 1,
        HKEY_CURRENT_USER = 2,
        HKEY_DYNDATA = 3,
        HKEY_LOCALE_MACHINE = 4,
        HKEY_PERFORMANCE_DATA = 5,
        HKEY_USERS = 6
    }
    class mRegistry
    {
     private RegistryKey GetRegKey(ERegistryPossibleRoots lngRoot)
        {
            try
            {
                switch (lngRoot)
                {
                    case ERegistryPossibleRoots.HKEY_CLASSES_ROOT:
                        return (Registry.ClassesRoot);
                    case ERegistryPossibleRoots.HKEY_CURRENT_CONFIG:
                        return (Registry.CurrentConfig);
                    case ERegistryPossibleRoots.HKEY_CURRENT_USER:
                        return (Registry.CurrentUser);
                    case ERegistryPossibleRoots.HKEY_DYNDATA:
                        return (Registry.DynData);
                    case ERegistryPossibleRoots.HKEY_LOCALE_MACHINE:
                        return (Registry.LocalMachine);
                    case ERegistryPossibleRoots.HKEY_PERFORMANCE_DATA:
                        return (Registry.PerformanceData);
                    case ERegistryPossibleRoots.HKEY_USERS:
                        return (Registry.Users);
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception("Eroare in GetRegKey!", ex);
            }
        }

       
        public bool DoesKeyExist(ERegistryPossibleRoots lngRootKey, string strKey)
        {
            RegistryKey objRegKey = null;

            try
            {
                objRegKey = GetRegKey(lngRootKey);
                objRegKey = objRegKey.OpenSubKey(strKey, false);

                if (objRegKey == null)
                    return false;
                else
                {
                    objRegKey.Close();
                    objRegKey = null;
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Eroare in DoesKeyExist!", ex);
            }
        }


       
        public bool CreateKey(ERegistryPossibleRoots lngrootkey, string strKey)
        {
            RegistryKey objRegKey = null;

            try
            {
                objRegKey = GetRegKey(lngrootkey);

                objRegKey = objRegKey.CreateSubKey(strKey);

                if (objRegKey == null)
                    return (false);
                else
                    return (true);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Eroare in CreateKey!", ex);
            }
            finally
            {
                try
                {
                    objRegKey.Close();
                }
                catch { }
                objRegKey = null;
            }
        }


       
        public bool DeleteKey(ERegistryPossibleRoots lngrootkey, string strKey, params bool[] bRecursive)
        {
            RegistryKey objRegKey = null;

            try
            {
                objRegKey = GetRegKey(lngrootkey);

                if (bRecursive.Length > 0)
                {
                    if (bRecursive[0])
                    {
                        objRegKey.DeleteSubKeyTree(strKey);
                    }
                    else
                    {
                        objRegKey.DeleteSubKey(strKey);
                    }
                }
                else
                    objRegKey.DeleteSubKey(strKey);

                return true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Eroare in DeleteKey", ex);
            }
            finally
            {
                if (objRegKey != null)
                {
                    try
                    {
                        objRegKey.Close();
                    }
                    catch { }
                }
                objRegKey = null;
            }
        }


        

        public string QueryValue(ERegistryPossibleRoots lngrootkey, string strKey, string strValName, string objDefault)
        {

            if (MyGlobal.OS_W_S_R == true)
            {
                    string TestKey = strKey;
                    RegistryKey cu = Registry.CurrentUser;
                    string user = Environment.UserDomainName + "\\" + Environment.UserName;
                    RegistrySecurity mSec = new RegistrySecurity();
                    RegistryAccessRule rule = new RegistryAccessRule(user,
                       RegistryRights.ReadKey | RegistryRights.WriteKey
                           | RegistryRights.Delete,InheritanceFlags.ContainerInherit,
                       PropagationFlags.None,AccessControlType.Allow);
                    mSec.AddAccessRule(rule);
                    rule = new RegistryAccessRule(user,
                        RegistryRights.ChangePermissions,
                        InheritanceFlags.ContainerInherit,
                        PropagationFlags.InheritOnly |
                            PropagationFlags.NoPropagateInherit,
                        AccessControlType.Allow);
                    mSec.AddAccessRule(rule);
                    RegistryKey rk = cu.CreateSubKey(TestKey,
                        RegistryKeyPermissionCheck.ReadWriteSubTree, mSec);
                    try
                    {
                        return rk.GetValue(strValName).ToString();
                    }
                    catch { return ""; } 

            }
            else
            {


                RegistryKey objRegKey = null;

                try
                {
                    objRegKey = GetRegKey(lngrootkey);
                    objRegKey = objRegKey.OpenSubKey(strKey);

                    return ((string)objRegKey.GetValue(strValName, objDefault));
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception("Eroare in QueryValue(string)!", ex);
                }
                finally
                {
                    if (objRegKey != null)
                    {
                        try
                        {
                            objRegKey.Close();
                        }
                        catch { }
                    }
                    objRegKey = null;
                }
            }
        }


        
        public byte[] QueryValue(ERegistryPossibleRoots lngrootkey, string strKey, string strValName, byte[] objDefault)
        {
            RegistryKey objRegKey = null;

            try
            {
                objRegKey = GetRegKey(lngrootkey);
                objRegKey = objRegKey.OpenSubKey(strKey);

                return ((byte[])objRegKey.GetValue(strValName, objDefault));
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Eroare in QueryValue(byte[])!", ex);
            }
            finally
            {
                if (objRegKey != null)
                {
                    try
                    {
                        objRegKey.Close();
                    }
                    catch { }
                }
                objRegKey = null;
            }
        }

        
        public int QueryValue(ERegistryPossibleRoots lngrootkey, string strKey, string strValName, int objDefault)
        {
            RegistryKey objRegKey = null;

            try
            {
                objRegKey = GetRegKey(lngrootkey);
                objRegKey = objRegKey.OpenSubKey(strKey);

                return ((int)objRegKey.GetValue(strValName, objDefault));
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Eroare in QueryValue(int)!", ex);
            }
            finally
            {
                if (objRegKey != null)
                {
                    try
                    {
                        objRegKey.Close();
                    }
                    catch { }
                }
                objRegKey = null;
            }
        }
        
        public bool CreateValue(ERegistryPossibleRoots lngrootkey, string strKey, string strValName, string objVal)
        {
            if (MyGlobal.OS_W_S_R == true)
            {
                string TestKey = strKey;
                RegistryKey cu = Registry.CurrentUser;
                string user = Environment.UserDomainName + "\\" + Environment.UserName;
                RegistrySecurity mSec = new RegistrySecurity();
                RegistryAccessRule rule = new RegistryAccessRule(user,
                   RegistryRights.ReadKey | RegistryRights.WriteKey
                       | RegistryRights.Delete, InheritanceFlags.ContainerInherit,
                   PropagationFlags.None, AccessControlType.Allow);
                mSec.AddAccessRule(rule);
                rule = new RegistryAccessRule(user,
                    RegistryRights.ChangePermissions,
                    InheritanceFlags.ContainerInherit,
                    PropagationFlags.InheritOnly |
                        PropagationFlags.NoPropagateInherit,
                    AccessControlType.Allow);
                mSec.AddAccessRule(rule);
                RegistryKey rk = cu.CreateSubKey(TestKey,
                    RegistryKeyPermissionCheck.ReadWriteSubTree, mSec);
                rk.SetValue(strValName,objVal.Trim());
                return true;

            }
            else
            {
                RegistryKey objRegKey = null;

                try
                {
                    objRegKey = GetRegKey(lngrootkey);
                    objRegKey = objRegKey.OpenSubKey(strKey, true);

                    if (objRegKey != null)
                    {
                        objRegKey.SetValue(strValName, objVal);
                        objRegKey.Flush();
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception("Eroare in CreateValue(string)!", ex);
                }
                finally
                {
                    try
                    {
                        objRegKey.Close();
                    }
                    catch { }
                    objRegKey = null;
                }
            }
        }

        
        public bool CreateValue(ERegistryPossibleRoots lngrootkey, string strKey, string strValName, byte[] objVal)
        {
            RegistryKey objRegKey = null;

            try
            {
                objRegKey = GetRegKey(lngrootkey);
                objRegKey = objRegKey.OpenSubKey(strKey, true);

                if (objRegKey != null)
                {
                    objRegKey.SetValue(strValName, objVal);
                    objRegKey.Flush();
                    return (true);
                }
                else
                    return (false);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Eroare in CreateValue(byte[])!", ex);
            }
            finally
            {
                try
                {
                    objRegKey.Close();
                }
                catch { }
                objRegKey = null;
            }
        }
        
        public bool CreateValue(ERegistryPossibleRoots lngrootkey, string strKey, string strValName, int objVal)
        {
            RegistryKey objRegKey = null;

            try
            {
                objRegKey = GetRegKey(lngrootkey);
                objRegKey = objRegKey.OpenSubKey(strKey, true);

                if (objRegKey != null)
                {
                    objRegKey.SetValue(strValName, objVal);
                    objRegKey.Flush();
                    return (true);
                }
                else
                    return (false);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Eroare in CreateValue(string)!", ex);
            }
            finally
            {
                try
                {
                    objRegKey.Close();
                }
                catch { }
                objRegKey = null;
            }
        }



        public bool DeleteValue(ERegistryPossibleRoots lngrootkey, string strKey, string strValName)
        {
            RegistryKey objRegKey = null;

            try
            {
                objRegKey = GetRegKey(lngrootkey);
                objRegKey = objRegKey.OpenSubKey(strKey, true);

                if (objRegKey != null)
                {
                    objRegKey.DeleteValue(strValName);
                    objRegKey.Flush();
                    return true;
                }
                else
                    return false;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Eroare in DeleteValue!", ex);
            }
            finally
            {
                try
                {
                    objRegKey.Close();
                }
                catch { }
                objRegKey = null;
            }
        }
    }
   
}
