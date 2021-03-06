﻿#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
 * $LastChangedBy: gbayon $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2008/2005 - The Apache Software Foundation
 *  
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 ********************************************************************************/
#endregion

using System;
using System.Collections.Generic;

namespace MyBatis.Common.Configuration
{

    /// <summary>
    /// This is an abstract <see cref="IConfiguration"/> implementation
    /// that deals with methods that can be abstracted away
    /// from underlying implementations.
    /// </summary>
    /// <remarks>
    /// <para><b>AbstractConfiguration</b> makes easier to implementers 
    /// to create a new version of <see cref="IConfiguration"/></para>
    /// </remarks>
    [Serializable]
    public class AbstractConfiguration : IConfiguration
    {
        /// <summary>
        /// The parent Configuration
        /// </summary>
        protected IConfiguration parentConfiguration = null;
        /// <summary>
        /// The internal node type
        /// </summary>
        protected string internalType= null;
        /// <summary>
        /// The internal node name
        /// </summary>
        protected string internalId = null;
        /// <summary>
        /// The internal node value
        /// </summary>
        protected string internalValue = null;
        protected IDictionary<string, string> attributes = new Dictionary<string, string>();
        private ConfigurationCollection children = new ConfigurationCollection();


        /// <summary>
        /// Gets the parent configuration
        /// </summary>
        /// <value>The parent.</value>
        public virtual IConfiguration Parent
        {
            set { parentConfiguration = value; }
            get { return parentConfiguration; }
        }

        /// <summary>
        /// Gets the type of the <see cref="IConfiguration"/>.
        /// </summary>
        /// <value>
        /// The type of the <see cref="IConfiguration"/>.
        /// </value>
        public virtual string Type
        {
            get { return internalType; }
        }

        /// <summary>
        /// Gets the id of the <see cref="IConfiguration"/>.
        /// </summary>
        /// <value>
        /// The id of the <see cref="IConfiguration"/>.
        /// </value>
        public virtual string Id
        {
            get { return internalId; }
        }

        /// <summary>
        /// Gets the value of <see cref="IConfiguration"/>.
        /// </summary>
        /// <value>
        /// The Value of the <see cref="IConfiguration"/>.
        /// </value>
        public virtual string Value
        {
            get { return internalValue; }
        }

        /// <summary>
        /// Gets all child nodes.
        /// </summary>
        /// <value>The <see cref="ConfigurationCollection"/> of child nodes.</value>
        public virtual ConfigurationCollection Children
        {
            get { return children; }
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The attribute value if find else null</returns>
        public virtual string GetAttributeValue(string key)
        {
            string val = null;
            attributes.TryGetValue(key, out val);
            return val;
        }

        /// <summary>
        /// Gets node attributes.
        /// </summary>
        /// <value>
        /// All attributes of the node.
        /// </value>
        public virtual IDictionary<string, string> Attributes
        {
            get { return attributes; }
        }

        /// <summary>
        /// Gets the value of the node and converts it
        /// into specified <see cref="System.Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="System.Type"/></param>
        /// <param name="defaultValue">
        /// The Default value returned if the convertion fails.
        /// </param>
        /// <returns>The Value converted into the specified type.</returns>
        public virtual object GetValue(Type type, object defaultValue)
        {
            try
            {
                return Convert.ChangeType(Value, type);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}
