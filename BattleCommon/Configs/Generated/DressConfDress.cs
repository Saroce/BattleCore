// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: DressConf_Dress.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ExcelConvert.Auto.DressConf {

  /// <summary>Holder for reflection information generated from DressConf_Dress.proto</summary>
  public static partial class DressConfDressReflection {

    #region Descriptor
    /// <summary>File descriptor for DressConf_Dress.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DressConfDressReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChVEcmVzc0NvbmZfRHJlc3MucHJvdG8SC1hsc3hDb252ZXJ0IkwKFkRyZXNz",
            "Q29uZl9EcmVzc19SZWNvcmQSDwoHRHJlc3NJZBgBIAEoBRIRCglHZW5lcmFs",
            "SWQYAiABKAUSDgoGQXZhdGFyGAMgASgJIkcKD0RyZXNzQ29uZl9EcmVzcxI0",
            "CgdyZWNvcmRzGAEgAygLMiMuWGxzeENvbnZlcnQuRHJlc3NDb25mX0RyZXNz",
            "X1JlY29yZEIeqgIbRXhjZWxDb252ZXJ0LkF1dG8uRHJlc3NDb25mYgZwcm90",
            "bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ExcelConvert.Auto.DressConf.DressConf_Dress_Record), global::ExcelConvert.Auto.DressConf.DressConf_Dress_Record.Parser, new[]{ "DressId", "GeneralId", "Avatar" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ExcelConvert.Auto.DressConf.DressConf_Dress), global::ExcelConvert.Auto.DressConf.DressConf_Dress.Parser, new[]{ "Records" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class DressConf_Dress_Record : pb::IMessage<DressConf_Dress_Record> {
    private static readonly pb::MessageParser<DressConf_Dress_Record> _parser = new pb::MessageParser<DressConf_Dress_Record>(() => new DressConf_Dress_Record());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DressConf_Dress_Record> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExcelConvert.Auto.DressConf.DressConfDressReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DressConf_Dress_Record() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DressConf_Dress_Record(DressConf_Dress_Record other) : this() {
      dressId_ = other.dressId_;
      generalId_ = other.generalId_;
      avatar_ = other.avatar_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DressConf_Dress_Record Clone() {
      return new DressConf_Dress_Record(this);
    }

    /// <summary>Field number for the "DressId" field.</summary>
    public const int DressIdFieldNumber = 1;
    private int dressId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int DressId {
      get { return dressId_; }
      set {
        dressId_ = value;
      }
    }

    /// <summary>Field number for the "GeneralId" field.</summary>
    public const int GeneralIdFieldNumber = 2;
    private int generalId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int GeneralId {
      get { return generalId_; }
      set {
        generalId_ = value;
      }
    }

    /// <summary>Field number for the "Avatar" field.</summary>
    public const int AvatarFieldNumber = 3;
    private string avatar_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Avatar {
      get { return avatar_; }
      set {
        avatar_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DressConf_Dress_Record);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DressConf_Dress_Record other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (DressId != other.DressId) return false;
      if (GeneralId != other.GeneralId) return false;
      if (Avatar != other.Avatar) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (DressId != 0) hash ^= DressId.GetHashCode();
      if (GeneralId != 0) hash ^= GeneralId.GetHashCode();
      if (Avatar.Length != 0) hash ^= Avatar.GetHashCode();
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
      if (DressId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(DressId);
      }
      if (GeneralId != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(GeneralId);
      }
      if (Avatar.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Avatar);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (DressId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(DressId);
      }
      if (GeneralId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(GeneralId);
      }
      if (Avatar.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Avatar);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DressConf_Dress_Record other) {
      if (other == null) {
        return;
      }
      if (other.DressId != 0) {
        DressId = other.DressId;
      }
      if (other.GeneralId != 0) {
        GeneralId = other.GeneralId;
      }
      if (other.Avatar.Length != 0) {
        Avatar = other.Avatar;
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
            DressId = input.ReadInt32();
            break;
          }
          case 16: {
            GeneralId = input.ReadInt32();
            break;
          }
          case 26: {
            Avatar = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class DressConf_Dress : pb::IMessage<DressConf_Dress> {
    private static readonly pb::MessageParser<DressConf_Dress> _parser = new pb::MessageParser<DressConf_Dress>(() => new DressConf_Dress());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DressConf_Dress> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExcelConvert.Auto.DressConf.DressConfDressReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DressConf_Dress() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DressConf_Dress(DressConf_Dress other) : this() {
      records_ = other.records_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DressConf_Dress Clone() {
      return new DressConf_Dress(this);
    }

    /// <summary>Field number for the "records" field.</summary>
    public const int RecordsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::ExcelConvert.Auto.DressConf.DressConf_Dress_Record> _repeated_records_codec
        = pb::FieldCodec.ForMessage(10, global::ExcelConvert.Auto.DressConf.DressConf_Dress_Record.Parser);
    private readonly pbc::RepeatedField<global::ExcelConvert.Auto.DressConf.DressConf_Dress_Record> records_ = new pbc::RepeatedField<global::ExcelConvert.Auto.DressConf.DressConf_Dress_Record>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::ExcelConvert.Auto.DressConf.DressConf_Dress_Record> Records {
      get { return records_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DressConf_Dress);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DressConf_Dress other) {
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
    public void MergeFrom(DressConf_Dress other) {
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