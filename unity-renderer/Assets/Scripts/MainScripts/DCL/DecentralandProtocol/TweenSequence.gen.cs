// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: decentraland/sdk/components/tween_sequence.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace DCL.ECSComponents {

  /// <summary>Holder for reflection information generated from decentraland/sdk/components/tween_sequence.proto</summary>
  public static partial class TweenSequenceReflection {

    #region Descriptor
    /// <summary>File descriptor for decentraland/sdk/components/tween_sequence.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TweenSequenceReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjBkZWNlbnRyYWxhbmQvc2RrL2NvbXBvbmVudHMvdHdlZW5fc2VxdWVuY2Uu",
            "cHJvdG8SG2RlY2VudHJhbGFuZC5zZGsuY29tcG9uZW50cxonZGVjZW50cmFs",
            "YW5kL3Nkay9jb21wb25lbnRzL3R3ZWVuLnByb3RvIo0BCg9QQlR3ZWVuU2Vx",
            "dWVuY2USNgoIc2VxdWVuY2UYASADKAsyJC5kZWNlbnRyYWxhbmQuc2RrLmNv",
            "bXBvbmVudHMuUEJUd2VlbhI5CgRsb29wGAIgASgOMiYuZGVjZW50cmFsYW5k",
            "LnNkay5jb21wb25lbnRzLlR3ZWVuTG9vcEgAiAEBQgcKBV9sb29wKigKCVR3",
            "ZWVuTG9vcBIOCgpUTF9SRVNUQVJUEAASCwoHVExfWU9ZTxABQhSqAhFEQ0wu",
            "RUNTQ29tcG9uZW50c2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::DCL.ECSComponents.TweenReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::DCL.ECSComponents.TweenLoop), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::DCL.ECSComponents.PBTweenSequence), global::DCL.ECSComponents.PBTweenSequence.Parser, new[]{ "Sequence", "Loop" }, new[]{ "Loop" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum TweenLoop {
    [pbr::OriginalName("TL_RESTART")] TlRestart = 0,
    [pbr::OriginalName("TL_YOYO")] TlYoyo = 1,
  }

  #endregion

  #region Messages
  public sealed partial class PBTweenSequence : pb::IMessage<PBTweenSequence>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<PBTweenSequence> _parser = new pb::MessageParser<PBTweenSequence>(() => new PBTweenSequence());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<PBTweenSequence> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::DCL.ECSComponents.TweenSequenceReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBTweenSequence() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBTweenSequence(PBTweenSequence other) : this() {
      _hasBits0 = other._hasBits0;
      sequence_ = other.sequence_.Clone();
      loop_ = other.loop_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PBTweenSequence Clone() {
      return new PBTweenSequence(this);
    }

    /// <summary>Field number for the "sequence" field.</summary>
    public const int SequenceFieldNumber = 1;
    private static readonly pb::FieldCodec<global::DCL.ECSComponents.PBTween> _repeated_sequence_codec
        = pb::FieldCodec.ForMessage(10, global::DCL.ECSComponents.PBTween.Parser);
    private readonly pbc::RepeatedField<global::DCL.ECSComponents.PBTween> sequence_ = new pbc::RepeatedField<global::DCL.ECSComponents.PBTween>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::DCL.ECSComponents.PBTween> Sequence {
      get { return sequence_; }
    }

    /// <summary>Field number for the "loop" field.</summary>
    public const int LoopFieldNumber = 2;
    private global::DCL.ECSComponents.TweenLoop loop_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::DCL.ECSComponents.TweenLoop Loop {
      get { if ((_hasBits0 & 1) != 0) { return loop_; } else { return global::DCL.ECSComponents.TweenLoop.TlRestart; } }
      set {
        _hasBits0 |= 1;
        loop_ = value;
      }
    }
    /// <summary>Gets whether the "loop" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasLoop {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "loop" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearLoop() {
      _hasBits0 &= ~1;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as PBTweenSequence);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(PBTweenSequence other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!sequence_.Equals(other.sequence_)) return false;
      if (Loop != other.Loop) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= sequence_.GetHashCode();
      if (HasLoop) hash ^= Loop.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      sequence_.WriteTo(output, _repeated_sequence_codec);
      if (HasLoop) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Loop);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      sequence_.WriteTo(ref output, _repeated_sequence_codec);
      if (HasLoop) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Loop);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += sequence_.CalculateSize(_repeated_sequence_codec);
      if (HasLoop) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Loop);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(PBTweenSequence other) {
      if (other == null) {
        return;
      }
      sequence_.Add(other.sequence_);
      if (other.HasLoop) {
        Loop = other.Loop;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            sequence_.AddEntriesFrom(input, _repeated_sequence_codec);
            break;
          }
          case 16: {
            Loop = (global::DCL.ECSComponents.TweenLoop) input.ReadEnum();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            sequence_.AddEntriesFrom(ref input, _repeated_sequence_codec);
            break;
          }
          case 16: {
            Loop = (global::DCL.ECSComponents.TweenLoop) input.ReadEnum();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code