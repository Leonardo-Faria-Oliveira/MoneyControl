﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoneyControl.Exception {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourcesErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourcesErrorMessages() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MoneyControl.Exception.ResourcesErrorMessages", typeof(ResourcesErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The amount must be more than zero.
        /// </summary>
        public static string AMOUNT_GREATHER_THAN_ZERO {
            get {
                return ResourceManager.GetString("AMOUNT_GREATHER_THAN_ZERO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The date must be today or before.
        /// </summary>
        public static string DATE_TODAY_BEFORE {
            get {
                return ResourceManager.GetString("DATE_TODAY_BEFORE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The email is already registered.
        /// </summary>
        public static string EMAIL_ALREADY_REGISTERED {
            get {
                return ResourceManager.GetString("EMAIL_ALREADY_REGISTERED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The email is required.
        /// </summary>
        public static string EMAIL_EMPTY {
            get {
                return ResourceManager.GetString("EMAIL_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The email must be valid.
        /// </summary>
        public static string EMAIL_INVALID {
            get {
                return ResourceManager.GetString("EMAIL_INVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The email or password is invalid.
        /// </summary>
        public static string EMAIL_OR_PASSWORD_INVALID {
            get {
                return ResourceManager.GetString("EMAIL_OR_PASSWORD_INVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Expense not found.
        /// </summary>
        public static string EXPENSE_NOT_FOUND {
            get {
                return ResourceManager.GetString("EXPENSE_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Your passowrd must contain less 8 characters, 1 uppercase letter, 1 lowercase a number and a special character.
        /// </summary>
        public static string INVALID_PASSWORD {
            get {
                return ResourceManager.GetString("INVALID_PASSWORD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The payment type must be valid.
        /// </summary>
        public static string INVALID_PAYMENT_TYPE {
            get {
                return ResourceManager.GetString("INVALID_PAYMENT_TYPE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The name is required.
        /// </summary>
        public static string NAME_EMPTY {
            get {
                return ResourceManager.GetString("NAME_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The title is required.
        /// </summary>
        public static string TITLE_REQUIRED {
            get {
                return ResourceManager.GetString("TITLE_REQUIRED", resourceCulture);
            }
        }
    }
}
