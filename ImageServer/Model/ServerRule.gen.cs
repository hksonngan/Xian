#region License

// Copyright (c) 2006-2009, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

// This file is auto-generated by the ClearCanvas.Model.SqlServer2005.CodeGenerator project.

namespace ClearCanvas.ImageServer.Model
{
    using System;
    using ClearCanvas.Enterprise.Core;
    using ClearCanvas.ImageServer.Enterprise;
    using ClearCanvas.ImageServer.Model.EntityBrokers;

    [Serializable]
    public partial class ServerRule: ServerEntity
    {
        #region Constructors
        public ServerRule():base("ServerRule")
        {}
        public ServerRule(
             System.Boolean _defaultRule_
            ,System.Boolean _enabled_
            ,System.Boolean _exemptRule_
            ,System.String _ruleName_
            ,System.Xml.XmlDocument _ruleXml_
            ,ClearCanvas.ImageServer.Enterprise.ServerEntityKey _serverPartitionKey_
            ,ServerRuleApplyTimeEnum _serverRuleApplyTimeEnum_
            ,ServerRuleTypeEnum _serverRuleTypeEnum_
            ):base("ServerRule")
        {
            _defaultRule = _defaultRule_;
            _enabled = _enabled_;
            _exemptRule = _exemptRule_;
            _ruleName = _ruleName_;
            _ruleXml = _ruleXml_;
            _serverPartitionKey = _serverPartitionKey_;
            _serverRuleApplyTimeEnum = _serverRuleApplyTimeEnum_;
            _serverRuleTypeEnum = _serverRuleTypeEnum_;
        }
        #endregion

        #region Private Members
        private System.Boolean _defaultRule;
        private System.Boolean _enabled;
        private System.Boolean _exemptRule;
        private System.String _ruleName;
        private System.Xml.XmlDocument _ruleXml;
        private ClearCanvas.ImageServer.Enterprise.ServerEntityKey _serverPartitionKey;
        private ServerRuleApplyTimeEnum _serverRuleApplyTimeEnum;
        private ServerRuleTypeEnum _serverRuleTypeEnum;
        #endregion

        #region Public Properties
        [EntityFieldDatabaseMappingAttribute(TableName="ServerRule", ColumnName="DefaultRule")]
        public System.Boolean DefaultRule
        {
        get { return _defaultRule; }
        set { _defaultRule = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerRule", ColumnName="Enabled")]
        public System.Boolean Enabled
        {
        get { return _enabled; }
        set { _enabled = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerRule", ColumnName="ExemptRule")]
        public System.Boolean ExemptRule
        {
        get { return _exemptRule; }
        set { _exemptRule = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerRule", ColumnName="RuleName")]
        public System.String RuleName
        {
        get { return _ruleName; }
        set { _ruleName = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerRule", ColumnName="RuleXml")]
        public System.Xml.XmlDocument RuleXml
        {
        get { return _ruleXml; }
        set { _ruleXml = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerRule", ColumnName="ServerPartitionGUID")]
        public ClearCanvas.ImageServer.Enterprise.ServerEntityKey ServerPartitionKey
        {
        get { return _serverPartitionKey; }
        set { _serverPartitionKey = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerRule", ColumnName="ServerRuleApplyTimeEnum")]
        public ServerRuleApplyTimeEnum ServerRuleApplyTimeEnum
        {
        get { return _serverRuleApplyTimeEnum; }
        set { _serverRuleApplyTimeEnum = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerRule", ColumnName="ServerRuleTypeEnum")]
        public ServerRuleTypeEnum ServerRuleTypeEnum
        {
        get { return _serverRuleTypeEnum; }
        set { _serverRuleTypeEnum = value; }
        }
        #endregion

        #region Static Methods
        static public ServerRule Load(ServerEntityKey key)
        {
            using (IReadContext read = PersistentStoreRegistry.GetDefaultStore().OpenReadContext())
            {
                return Load(read, key);
            }
        }
        static public ServerRule Load(IPersistenceContext read, ServerEntityKey key)
        {
            IServerRuleEntityBroker broker = read.GetBroker<IServerRuleEntityBroker>();
            ServerRule theObject = broker.Load(key);
            return theObject;
        }
        static public ServerRule Insert(ServerRule entity)
        {
            using (IUpdateContext update = PersistentStoreRegistry.GetDefaultStore().OpenUpdateContext(UpdateContextSyncMode.Flush))
            {
                ServerRule newEntity = Insert(update, entity);
                update.Commit();
                return newEntity;
            }
        }
        static public ServerRule Insert(IUpdateContext update, ServerRule entity)
        {
            IServerRuleEntityBroker broker = update.GetBroker<IServerRuleEntityBroker>();
            ServerRuleUpdateColumns updateColumns = new ServerRuleUpdateColumns();
            updateColumns.DefaultRule = entity.DefaultRule;
            updateColumns.Enabled = entity.Enabled;
            updateColumns.ExemptRule = entity.ExemptRule;
            updateColumns.RuleName = entity.RuleName;
            updateColumns.RuleXml = entity.RuleXml;
            updateColumns.ServerPartitionKey = entity.ServerPartitionKey;
            updateColumns.ServerRuleApplyTimeEnum = entity.ServerRuleApplyTimeEnum;
            updateColumns.ServerRuleTypeEnum = entity.ServerRuleTypeEnum;
            ServerRule newEntity = broker.Insert(updateColumns);
            return newEntity;
        }
        #endregion
    }
}
