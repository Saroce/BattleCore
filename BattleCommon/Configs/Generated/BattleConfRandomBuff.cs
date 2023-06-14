// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: BattleConf_RandomBuff.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ExcelConvert.Auto.BattleConf {

  /// <summary>Holder for reflection information generated from BattleConf_RandomBuff.proto</summary>
  public static partial class BattleConfRandomBuffReflection {

    #region Descriptor
    /// <summary>File descriptor for BattleConf_RandomBuff.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static BattleConfRandomBuffReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChtCYXR0bGVDb25mX1JhbmRvbUJ1ZmYucHJvdG8SC1hsc3hDb252ZXJ0Ik4K",
            "HEJhdHRsZUNvbmZfUmFuZG9tQnVmZl9SZWNvcmQSDgoGQnVmZklEGAEgASgF",
            "Eg4KBlZhbHVlMRgCIAEoCRIOCgZWYWx1ZTIYAyABKAkiUwoVQmF0dGxlQ29u",
            "Zl9SYW5kb21CdWZmEjoKB3JlY29yZHMYASADKAsyKS5YbHN4Q29udmVydC5C",
            "YXR0bGVDb25mX1JhbmRvbUJ1ZmZfUmVjb3JkQh+qAhxFeGNlbENvbnZlcnQu",
            "QXV0by5CYXR0bGVDb25mYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ExcelConvert.Auto.BattleConf.BattleConf_RandomBuff_Record), global::ExcelConvert.Auto.BattleConf.BattleConf_RandomBuff_Record.Parser, new[]{ "BuffID", "Value1", "Value2" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ExcelConvert.Auto.BattleConf.BattleConf_RandomBuff), global::ExcelConvert.Auto.BattleConf.BattleConf_RandomBuff.Parser, new[]{ "Records" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class BattleConf_RandomBuff_Record : pb::IMessage<BattleConf_RandomBuff_Record> {
    private static readonly pb::MessageParser<BattleConf_RandomBuff_Record> _parser = new pb::MessageParser<BattleConf_RandomBuff_Record>(() => new BattleConf_RandomBuff_Record());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BattleConf_RandomBuff_Record> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExcelConvert.Auto.BattleConf.BattleConfRandomBuffReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BattleConf_RandomBuff_Record() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BattleConf_RandomBuff_Record(BattleConf_RandomBuff_Record other) : this() {
      buffID_ = other.buffID_;
      value1_ = other.value1_;
      value2_ = other.value2_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BattleConf_RandomBuff_Record Clone() {
      return new BattleConf_RandomBuff_Record(this);
    }

    /// <summary>Field number for the "BuffID" field.</summary>
    public const int BuffIDFieldNumber = 1;
    private int buffID_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int BuffID {
      get { return buffID_; }
      set {
        buffID_ = value;
      }
    }

    /// <summary>Field number for the "Value1" field.</summary>
    public const int Value1FieldNumber = 2;
    private string value1_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Value1 {
      get { return value1_; }
      set {
        value1_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Value2" field.</summary>
    public const int Value2FieldNumber = 3;
    private string value2_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Value2 {
      get { return value2_; }
      set {
        value2_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as BattleConf_RandomBuff_Record);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(BattleConf_RandomBuff_Record other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (BuffID != other.BuffID) return false;
      if (Value1 != other.Value1) return false;
      if (Value2 != other.Value2) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (BuffID != 0) hash ^= BuffID.GetHashCode();
      if (Value1.Length != 0) hash ^= Value1.GetHashCode();
      if (Value2.Length != 0) hash ^= Value2.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (BuffID != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(BuffID);
      }
      if (Value1.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Value1);
      }
      if (Value2.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Value2);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (BuffID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(BuffID);
      }
      if (Value1.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Value1);
      }
      if (Value2.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Value2);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(BattleConf_RandomBuff_Record other) {
      if (other == null) {
        return;
      }
      if (other.BuffID != 0) {
        BuffID = other.BuffID;
      }
      if (other.Value1.Length != 0) {
        Value1 = other.Value1;
      }
      if (other.Value2.Length != 0) {
        Value2 = other.Value2;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            BuffID = input.ReadInt32();
            break;
          }
          case 18: {
            Value1 = input.ReadString();
            break;
          }
          case 26: {
            Value2 = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class BattleConf_RandomBuff : pb::IMessage<BattleConf_RandomBuff> {
    private static readonly pb::MessageParser<BattleConf_RandomBuff> _parser = new pb::MessageParser<BattleConf_RandomBuff>(() => new BattleConf_RandomBuff());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BattleConf_RandomBuff> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExcelConvert.Auto.BattleConf.BattleConfRandomBuffReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BattleConf_RandomBuff() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BattleConf_RandomBuff(BattleConf_RandomBuff other) : this() {
      records_ = other.records_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BattleConf_RandomBuff Clone() {
      return new BattleConf_RandomBuff(this);
    }

    /// <summary>Field number for the "records" field.</summary>
    public const int RecordsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::ExcelConvert.Auto.BattleConf.BattleConf_RandomBuff_Record> _repeated_records_codec
        = pb::FieldCodec.ForMessage(10, global::ExcelConvert.Auto.BattleConf.BattleConf_RandomBuff_Record.Parser);
    private readonly pbc::RepeatedField<global::ExcelConvert.Auto.BattleConf.BattleConf_RandomBuff_Record> records_ = new pbc::RepeatedField<global::ExcelConvert.Auto.BattleConf.BattleConf_RandomBuff_Record>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::ExcelConvert.Auto.BattleConf.BattleConf_RandomBuff_Record> Records {
      get { return records_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as BattleConf_RandomBuff);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(BattleConf_RandomBuff other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!records_.Equals(other.records_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= records_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      records_.WriteTo(output, _repeated_records_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += records_.CalculateSize(_repeated_records_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(BattleConf_RandomBuff other) {
      if (other == null) {
        return;
      }
      records_.Add(other.records_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            records_.AddEntriesFrom(input, _repeated_records_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code