// Generated by github.com/davyxu/tabtoy
// Version: 2.6.0
// DO NOT EDIT!!
using System.Collections.Generic;
using System.IO;

namespace gamedef
{
	
	public enum ActorType
	{
		
		// 格斗士
		Fighter = 0, 
		
		// 超能
		Power = 21, 
	
	}
	
	
	public partial class Config : tabtoy.DataObject
	{
		public tabtoy.Logger TableLogger = new tabtoy.Logger();
		
		
		
		public List<SampleDefine> Sample = new List<SampleDefine>(); // Sample
		
		
		public List<ExpDefine> Exp = new List<ExpDefine>(); // Exp
	
	
	
	 	Dictionary<long, SampleDefine> _SampleByID = new Dictionary<long, SampleDefine>();
        public SampleDefine GetSampleByID(long ID, SampleDefine def = default(SampleDefine))
        {
            SampleDefine ret;
            if ( _SampleByID.TryGetValue( ID, out ret ) )
            {
                return ret;
            }
			
			if ( def == default(SampleDefine) )
			{
				TableLogger.ErrorLine("GetSampleByID failed, ID: {0}", ID);
			}

            return def;
        }
	
	 	Dictionary<string, SampleDefine> _SampleByName = new Dictionary<string, SampleDefine>();
        public SampleDefine GetSampleByName(string Name, SampleDefine def = default(SampleDefine))
        {
            SampleDefine ret;
            if ( _SampleByName.TryGetValue( Name, out ret ) )
            {
                return ret;
            }
			
			if ( def == default(SampleDefine) )
			{
				TableLogger.ErrorLine("GetSampleByName failed, Name: {0}", Name);
			}

            return def;
        }
	
	 	Dictionary<int, ExpDefine> _ExpByLevel = new Dictionary<int, ExpDefine>();
        public ExpDefine GetExpByLevel(int Level, ExpDefine def = default(ExpDefine))
        {
            ExpDefine ret;
            if ( _ExpByLevel.TryGetValue( Level, out ret ) )
            {
                return ret;
            }
			
			if ( def == default(ExpDefine) )
			{
				TableLogger.ErrorLine("GetExpByLevel failed, Level: {0}", Level);
			}

            return def;
        }
	
		public void Deserialize( tabtoy.DataReader reader )
		{
			
			// Sample
			if ( reader.MatchTag(0x90000) )
			{
				reader.ReadList_Struct<SampleDefine>( this.Sample );
			}
			
			// Exp
			if ( reader.MatchTag(0x90001) )
			{
				reader.ReadList_Struct<ExpDefine>( this.Exp );
			}
			
			
			// Build Sample Index
            for( int i = 0;i< this.Sample.Count;i++)
            {
                var element = this.Sample[i];
				
                _SampleByID.Add(element.ID, element);                
				
                _SampleByName.Add(element.Name, element);                
				
            }
			
			// Build Exp Index
            for( int i = 0;i< this.Exp.Count;i++)
            {
                var element = this.Exp[i];
				
                _ExpByLevel.Add(element.Level, element);                
				
            }
			
		}
	}
	
	public partial class Prop : tabtoy.DataObject
	{
		public tabtoy.Logger TableLogger = new tabtoy.Logger();
		
		
		// 血量
		public int HP = 10; 
		
		// 攻击速率
		public float AttackRate = 0; 
		
		// 额外类型
		public ActorType ExType = ActorType.Fighter; 
	
	
	
		public void Deserialize( tabtoy.DataReader reader )
		{
			
			
			if ( reader.MatchTag(0x10000) )
			{
				this.HP = reader.ReadInt32( );
			}
			
			
			if ( reader.MatchTag(0x50001) )
			{
				this.AttackRate = reader.ReadFloat( );
			}
			
			
			if ( reader.MatchTag(0x80002) )
			{
				this.ExType = reader.ReadEnum<ActorType>( );
			}
			
			
		}
	}
	
	public partial class SampleDefine : tabtoy.DataObject
	{
		public tabtoy.Logger TableLogger = new tabtoy.Logger();
		
		
		
		public long ID = 0; // 唯一ID
		
		
		public string Name = ""; // 名称
		
		
		public int IconID = 0; // 图标ID
		
		
		public float NumericalRate = 0; // 攻击率
		
		
		public int ItemID = 100; // 物品id
		
		
		public List<int> BuffID = new List<int>(); // BuffID
		
		
		public ActorType Type = ActorType.Fighter; // 类型
		
		
		public List<int> SkillID = new List<int>(); // 技能ID列表
		
		
		public Prop SingleStruct = new Prop(); // 单结构解析
		
		
		public List<Prop> StrStruct = new List<Prop>(); // 字符串结构
	
	
	
		public void Deserialize( tabtoy.DataReader reader )
		{
			
			// 唯一ID
			if ( reader.MatchTag(0x20000) )
			{
				this.ID = reader.ReadInt64( );
			}
			
			// 名称
			if ( reader.MatchTag(0x60001) )
			{
				this.Name = reader.ReadString( );
			}
			
			// 图标ID
			if ( reader.MatchTag(0x10002) )
			{
				this.IconID = reader.ReadInt32( );
			}
			
			// 攻击率
			if ( reader.MatchTag(0x50003) )
			{
				this.NumericalRate = reader.ReadFloat( );
			}
			
			// 物品id
			if ( reader.MatchTag(0x10004) )
			{
				this.ItemID = reader.ReadInt32( );
			}
			
			// BuffID
			if ( reader.MatchTag(0x10005) )
			{
				reader.ReadList_Int32( this.BuffID );
			}
			
			// 类型
			if ( reader.MatchTag(0x80006) )
			{
				this.Type = reader.ReadEnum<ActorType>( );
			}
			
			// 技能ID列表
			if ( reader.MatchTag(0x10007) )
			{
				reader.ReadList_Int32( this.SkillID );
			}
			
			// 单结构解析
			if ( reader.MatchTag(0x90008) )
			{
				this.SingleStruct = reader.ReadStruct<Prop>( );
			}
			
			// 字符串结构
			if ( reader.MatchTag(0x90009) )
			{
				reader.ReadList_Struct<Prop>( this.StrStruct );
			}
			
			
		}
	}
	
	public partial class ExpDefine : tabtoy.DataObject
	{
		public tabtoy.Logger TableLogger = new tabtoy.Logger();
		
		
		
		public int Level = 0; // 唯一ID
		
		
		public int Exp = 0; // 经验值
		
		
		public bool BoolChecker = false; // 布尔检查
		
		
		public ActorType Type = ActorType.Fighter; // 类型
	
	
	
		public void Deserialize( tabtoy.DataReader reader )
		{
			
			// 唯一ID
			if ( reader.MatchTag(0x10000) )
			{
				this.Level = reader.ReadInt32( );
			}
			
			// 经验值
			if ( reader.MatchTag(0x10001) )
			{
				this.Exp = reader.ReadInt32( );
			}
			
			// 布尔检查
			if ( reader.MatchTag(0x70002) )
			{
				this.BoolChecker = reader.ReadBool( );
			}
			
			// 类型
			if ( reader.MatchTag(0x80003) )
			{
				this.Type = reader.ReadEnum<ActorType>( );
			}
			
			
		}
	}
	

}
