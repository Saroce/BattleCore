// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: ExcelIndexer.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ExcelConvert.Auto.Indexers {

  /// <summary>Holder for reflection information generated from ExcelIndexer.proto</summary>
  public static partial class ExcelIndexerReflection {

    #region Descriptor
    /// <summary>File descriptor for ExcelIndexer.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ExcelIndexerReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChJFeGNlbEluZGV4ZXIucHJvdG8SC1hsc3hDb252ZXJ0IiIKEEV4Y2VsUmVj",
            "b3JkSW5kZXgSDgoGdmFsdWVzGAEgAygFIpkBCg9FeGNlbEluZGV4R3JvdXAS",
            "OAoGdmFsdWVzGAEgAygLMiguWGxzeENvbnZlcnQuRXhjZWxJbmRleEdyb3Vw",
            "LlZhbHVlc0VudHJ5GkwKC1ZhbHVlc0VudHJ5EgsKA2tleRgBIAEoCRIsCgV2",
            "YWx1ZRgCIAEoCzIdLlhsc3hDb252ZXJ0LkV4Y2VsUmVjb3JkSW5kZXg6AjgB",
            "IpIBCgxFeGNlbEluZGV4ZXISNQoGdmFsdWVzGAEgAygLMiUuWGxzeENvbnZl",
            "cnQuRXhjZWxJbmRleGVyLlZhbHVlc0VudHJ5GksKC1ZhbHVlc0VudHJ5EgsK",
            "A2tleRgBIAEoCRIrCgV2YWx1ZRgCIAEoCzIcLlhsc3hDb252ZXJ0LkV4Y2Vs",
            "SW5kZXhHcm91cDoCOAFCHaoCGkV4Y2VsQ29udmVydC5BdXRvLkluZGV4ZXJz",
            "YgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ExcelConvert.Auto.Indexers.ExcelRecordIndex), global::ExcelConvert.Auto.Indexers.ExcelRecordIndex.Parser, new[]{ "Values" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ExcelConvert.Auto.Indexers.ExcelIndexGroup), global::ExcelConvert.Auto.Indexers.ExcelIndexGroup.Parser, new[]{ "Values" }, null, null, null, new pbr::GeneratedClrTypeInfo[] { null, }),
            new pbr::GeneratedClrTypeInfo(typeof(global::ExcelConvert.Auto.Indexers.ExcelIndexer), global::ExcelConvert.Auto.Indexers.ExcelIndexer.Parser, new[]{ "Values" }, null, null, null, new pbr::GeneratedClrTypeInfo[] { null, })
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Record excel row data indexes
  /// </summary>
  public sealed partial class ExcelRecordIndex : pb::IMessage<ExcelRecordIndex> {
    private static readonly pb::MessageParser<ExcelRecordIndex> _parser = new pb::MessageParser<ExcelRecordIndex>(() => new ExcelRecordIndex());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ExcelRecordIndex> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExcelConvert.Auto.Indexers.ExcelIndexerReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExcelRecordIndex() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExcelRecordIndex(ExcelRecordIndex other) : this() {
      values_ = other.values_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExcelRecordIndex Clone() {
      return new ExcelRecordIndex(this);
    }

    /// <summary>Field number for the "values" field.</summary>
    public const int ValuesFieldNumber = 1;
    private static readonly pb::FieldCodec<int> _repeated_values_codec
        = pb::FieldCodec.ForInt32(10);
    private readonly pbc::RepeatedField<int> values_ = new pbc::RepeatedField<int>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> Values {
      get { return values_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ExcelRecordIndex);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ExcelRecordIndex other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!values_.Equals(other.values_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= values_.GetHashCode();
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
      values_.WriteTo(output, _repeated_values_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += values_.CalculateSize(_repeated_values_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ExcelRecordIndex other) {
      if (other == null) {
        return;
      }
      values_.Add(other.values_);
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
          case 10:
          case 8: {
            values_.AddEntriesFrom(input, _repeated_values_codec);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// key == Multiple key value compose hash, value = row data indexes
  /// </summary>
  public sealed partial class ExcelIndexGroup : pb::IMessage<ExcelIndexGroup> {
    private static readonly pb::MessageParser<ExcelIndexGroup> _parser = new pb::MessageParser<ExcelIndexGroup>(() => new ExcelIndexGroup());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ExcelIndexGroup> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExcelConvert.Auto.Indexers.ExcelIndexerReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExcelIndexGroup() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExcelIndexGroup(ExcelIndexGroup other) : this() {
      values_ = other.values_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExcelIndexGroup Clone() {
      return new ExcelIndexGroup(this);
    }

    /// <summary>Field number for the "values" field.</summary>
    public const int ValuesFieldNumber = 1;
    private static readonly pbc::MapField<string, global::ExcelConvert.Auto.Indexers.ExcelRecordIndex>.Codec _map_values_codec
        = new pbc::MapField<string, global::ExcelConvert.Auto.Indexers.ExcelRecordIndex>.Codec(pb::FieldCodec.ForString(10, ""), pb::FieldCodec.ForMessage(18, global::ExcelConvert.Auto.Indexers.ExcelRecordIndex.Parser), 10);
    private readonly pbc::MapField<string, global::ExcelConvert.Auto.Indexers.ExcelRecordIndex> values_ = new pbc::MapField<string, global::ExcelConvert.Auto.Indexers.ExcelRecordIndex>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, global::ExcelConvert.Auto.Indexers.ExcelRecordIndex> Values {
      get { return values_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ExcelIndexGroup);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ExcelIndexGroup other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!Values.Equals(other.Values)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= Values.GetHashCode();
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
      values_.WriteTo(output, _map_values_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += values_.CalculateSize(_map_values_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ExcelIndexGroup other) {
      if (other == null) {
        return;
      }
      values_.Add(other.values_);
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
            values_.AddEntriesFrom(input, _map_values_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class ExcelIndexer : pb::IMessage<ExcelIndexer> {
    private static readonly pb::MessageParser<ExcelIndexer> _parser = new pb::MessageParser<ExcelIndexer>(() => new ExcelIndexer());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ExcelIndexer> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExcelConvert.Auto.Indexers.ExcelIndexerReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExcelIndexer() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExcelIndexer(ExcelIndexer other) : this() {
      values_ = other.values_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExcelIndexer Clone() {
      return new ExcelIndexer(this);
    }

    /// <summary>Field number for the "values" field.</summary>
    public const int ValuesFieldNumber = 1;
    private static readonly pbc::MapField<string, global::ExcelConvert.Auto.Indexers.ExcelIndexGroup>.Codec _map_values_codec
        = new pbc::MapField<string, global::ExcelConvert.Auto.Indexers.ExcelIndexGroup>.Codec(pb::FieldCodec.ForString(10, ""), pb::FieldCodec.ForMessage(18, global::ExcelConvert.Auto.Indexers.ExcelIndexGroup.Parser), 10);
    private readonly pbc::MapField<string, global::ExcelConvert.Auto.Indexers.ExcelIndexGroup> values_ = new pbc::MapField<string, global::ExcelConvert.Auto.Indexers.ExcelIndexGroup>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, global::ExcelConvert.Auto.Indexers.ExcelIndexGroup> Values {
      get { return values_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ExcelIndexer);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ExcelIndexer other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!Values.Equals(other.Values)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= Values.GetHashCode();
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
      values_.WriteTo(output, _map_values_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += values_.CalculateSize(_map_values_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ExcelIndexer other) {
      if (other == null) {
        return;
      }
      values_.Add(other.values_);
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
            values_.AddEntriesFrom(input, _map_values_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
