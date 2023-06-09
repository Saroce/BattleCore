// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: SkillConf_SkillLevel.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ExcelConvert.Auto.SkillConf {

  /// <summary>Holder for reflection information generated from SkillConf_SkillLevel.proto</summary>
  public static partial class SkillConfSkillLevelReflection {

    #region Descriptor
    /// <summary>File descriptor for SkillConf_SkillLevel.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SkillConfSkillLevelReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChpTa2lsbENvbmZfU2tpbGxMZXZlbC5wcm90bxILWGxzeENvbnZlcnQiWQob",
            "U2tpbGxDb25mX1NraWxsTGV2ZWxfUmVjb3JkEg8KB1NraWxsSWQYASABKAUS",
            "EgoKU2tpbGxMZXZlbBgCIAEoBRIVCg1Ta2lsbENvbmZQYXRoGAMgASgJIlEK",
            "FFNraWxsQ29uZl9Ta2lsbExldmVsEjkKB3JlY29yZHMYASADKAsyKC5YbHN4",
            "Q29udmVydC5Ta2lsbENvbmZfU2tpbGxMZXZlbF9SZWNvcmRCHqoCG0V4Y2Vs",
            "Q29udmVydC5BdXRvLlNraWxsQ29uZmIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ExcelConvert.Auto.SkillConf.SkillConf_SkillLevel_Record), global::ExcelConvert.Auto.SkillConf.SkillConf_SkillLevel_Record.Parser, new[]{ "SkillId", "SkillLevel", "SkillConfPath" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ExcelConvert.Auto.SkillConf.SkillConf_SkillLevel), global::ExcelConvert.Auto.SkillConf.SkillConf_SkillLevel.Parser, new[]{ "Records" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SkillConf_SkillLevel_Record : pb::IMessage<SkillConf_SkillLevel_Record> {
    private static readonly pb::MessageParser<SkillConf_SkillLevel_Record> _parser = new pb::MessageParser<SkillConf_SkillLevel_Record>(() => new SkillConf_SkillLevel_Record());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SkillConf_SkillLevel_Record> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExcelConvert.Auto.SkillConf.SkillConfSkillLevelReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SkillConf_SkillLevel_Record() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SkillConf_SkillLevel_Record(SkillConf_SkillLevel_Record other) : this() {
      skillId_ = other.skillId_;
      skillLevel_ = other.skillLevel_;
      skillConfPath_ = other.skillConfPath_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SkillConf_SkillLevel_Record Clone() {
      return new SkillConf_SkillLevel_Record(this);
    }

    /// <summary>Field number for the "SkillId" field.</summary>
    public const int SkillIdFieldNumber = 1;
    private int skillId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int SkillId {
      get { return skillId_; }
      set {
        skillId_ = value;
      }
    }

    /// <summary>Field number for the "SkillLevel" field.</summary>
    public const int SkillLevelFieldNumber = 2;
    private int skillLevel_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int SkillLevel {
      get { return skillLevel_; }
      set {
        skillLevel_ = value;
      }
    }

    /// <summary>Field number for the "SkillConfPath" field.</summary>
    public const int SkillConfPathFieldNumber = 3;
    private string skillConfPath_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string SkillConfPath {
      get { return skillConfPath_; }
      set {
        skillConfPath_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SkillConf_SkillLevel_Record);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SkillConf_SkillLevel_Record other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (SkillId != other.SkillId) return false;
      if (SkillLevel != other.SkillLevel) return false;
      if (SkillConfPath != other.SkillConfPath) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (SkillId != 0) hash ^= SkillId.GetHashCode();
      if (SkillLevel != 0) hash ^= SkillLevel.GetHashCode();
      if (SkillConfPath.Length != 0) hash ^= SkillConfPath.GetHashCode();
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
      if (SkillId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(SkillId);
      }
      if (SkillLevel != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(SkillLevel);
      }
      if (SkillConfPath.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(SkillConfPath);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (SkillId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(SkillId);
      }
      if (SkillLevel != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(SkillLevel);
      }
      if (SkillConfPath.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SkillConfPath);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SkillConf_SkillLevel_Record other) {
      if (other == null) {
        return;
      }
      if (other.SkillId != 0) {
        SkillId = other.SkillId;
      }
      if (other.SkillLevel != 0) {
        SkillLevel = other.SkillLevel;
      }
      if (other.SkillConfPath.Length != 0) {
        SkillConfPath = other.SkillConfPath;
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
            SkillId = input.ReadInt32();
            break;
          }
          case 16: {
            SkillLevel = input.ReadInt32();
            break;
          }
          case 26: {
            SkillConfPath = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class SkillConf_SkillLevel : pb::IMessage<SkillConf_SkillLevel> {
    private static readonly pb::MessageParser<SkillConf_SkillLevel> _parser = new pb::MessageParser<SkillConf_SkillLevel>(() => new SkillConf_SkillLevel());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SkillConf_SkillLevel> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExcelConvert.Auto.SkillConf.SkillConfSkillLevelReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SkillConf_SkillLevel() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SkillConf_SkillLevel(SkillConf_SkillLevel other) : this() {
      records_ = other.records_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SkillConf_SkillLevel Clone() {
      return new SkillConf_SkillLevel(this);
    }

    /// <summary>Field number for the "records" field.</summary>
    public const int RecordsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::ExcelConvert.Auto.SkillConf.SkillConf_SkillLevel_Record> _repeated_records_codec
        = pb::FieldCodec.ForMessage(10, global::ExcelConvert.Auto.SkillConf.SkillConf_SkillLevel_Record.Parser);
    private readonly pbc::RepeatedField<global::ExcelConvert.Auto.SkillConf.SkillConf_SkillLevel_Record> records_ = new pbc::RepeatedField<global::ExcelConvert.Auto.SkillConf.SkillConf_SkillLevel_Record>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::ExcelConvert.Auto.SkillConf.SkillConf_SkillLevel_Record> Records {
      get { return records_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SkillConf_SkillLevel);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SkillConf_SkillLevel other) {
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
    public void MergeFrom(SkillConf_SkillLevel other) {
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
