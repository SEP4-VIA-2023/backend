// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: preset.proto

package protos;

/**
 * Protobuf type {@code GetPresetResponse}
 */
public final class GetPresetResponse extends
    com.google.protobuf.GeneratedMessageV3 implements
    // @@protoc_insertion_point(message_implements:GetPresetResponse)
    GetPresetResponseOrBuilder {
private static final long serialVersionUID = 0L;
  // Use GetPresetResponse.newBuilder() to construct.
  private GetPresetResponse(com.google.protobuf.GeneratedMessageV3.Builder<?> builder) {
    super(builder);
  }
  private GetPresetResponse() {
  }

  @java.lang.Override
  @SuppressWarnings({"unused"})
  protected java.lang.Object newInstance(
      UnusedPrivateParameter unused) {
    return new GetPresetResponse();
  }

  @java.lang.Override
  public final com.google.protobuf.UnknownFieldSet
  getUnknownFields() {
    return this.unknownFields;
  }
  private GetPresetResponse(
      com.google.protobuf.CodedInputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    this();
    if (extensionRegistry == null) {
      throw new java.lang.NullPointerException();
    }
    com.google.protobuf.UnknownFieldSet.Builder unknownFields =
        com.google.protobuf.UnknownFieldSet.newBuilder();
    try {
      boolean done = false;
      while (!done) {
        int tag = input.readTag();
        switch (tag) {
          case 0:
            done = true;
            break;
          case 10: {
            protos.PresetObj.Builder subBuilder = null;
            if (preset_ != null) {
              subBuilder = preset_.toBuilder();
            }
            preset_ = input.readMessage(protos.PresetObj.parser(), extensionRegistry);
            if (subBuilder != null) {
              subBuilder.mergeFrom(preset_);
              preset_ = subBuilder.buildPartial();
            }

            break;
          }
          default: {
            if (!parseUnknownField(
                input, unknownFields, extensionRegistry, tag)) {
              done = true;
            }
            break;
          }
        }
      }
    } catch (com.google.protobuf.InvalidProtocolBufferException e) {
      throw e.setUnfinishedMessage(this);
    } catch (com.google.protobuf.UninitializedMessageException e) {
      throw e.asInvalidProtocolBufferException().setUnfinishedMessage(this);
    } catch (java.io.IOException e) {
      throw new com.google.protobuf.InvalidProtocolBufferException(
          e).setUnfinishedMessage(this);
    } finally {
      this.unknownFields = unknownFields.build();
      makeExtensionsImmutable();
    }
  }
  public static final com.google.protobuf.Descriptors.Descriptor
      getDescriptor() {
    return protos.Preset.internal_static_GetPresetResponse_descriptor;
  }

  @java.lang.Override
  protected com.google.protobuf.GeneratedMessageV3.FieldAccessorTable
      internalGetFieldAccessorTable() {
    return protos.Preset.internal_static_GetPresetResponse_fieldAccessorTable
        .ensureFieldAccessorsInitialized(
            protos.GetPresetResponse.class, protos.GetPresetResponse.Builder.class);
  }

  public static final int PRESET_FIELD_NUMBER = 1;
  private protos.PresetObj preset_;
  /**
   * <code>.PresetObj preset = 1;</code>
   * @return Whether the preset field is set.
   */
  @java.lang.Override
  public boolean hasPreset() {
    return preset_ != null;
  }
  /**
   * <code>.PresetObj preset = 1;</code>
   * @return The preset.
   */
  @java.lang.Override
  public protos.PresetObj getPreset() {
    return preset_ == null ? protos.PresetObj.getDefaultInstance() : preset_;
  }
  /**
   * <code>.PresetObj preset = 1;</code>
   */
  @java.lang.Override
  public protos.PresetObjOrBuilder getPresetOrBuilder() {
    return getPreset();
  }

  private byte memoizedIsInitialized = -1;
  @java.lang.Override
  public final boolean isInitialized() {
    byte isInitialized = memoizedIsInitialized;
    if (isInitialized == 1) return true;
    if (isInitialized == 0) return false;

    memoizedIsInitialized = 1;
    return true;
  }

  @java.lang.Override
  public void writeTo(com.google.protobuf.CodedOutputStream output)
                      throws java.io.IOException {
    if (preset_ != null) {
      output.writeMessage(1, getPreset());
    }
    unknownFields.writeTo(output);
  }

  @java.lang.Override
  public int getSerializedSize() {
    int size = memoizedSize;
    if (size != -1) return size;

    size = 0;
    if (preset_ != null) {
      size += com.google.protobuf.CodedOutputStream
        .computeMessageSize(1, getPreset());
    }
    size += unknownFields.getSerializedSize();
    memoizedSize = size;
    return size;
  }

  @java.lang.Override
  public boolean equals(final java.lang.Object obj) {
    if (obj == this) {
     return true;
    }
    if (!(obj instanceof protos.GetPresetResponse)) {
      return super.equals(obj);
    }
    protos.GetPresetResponse other = (protos.GetPresetResponse) obj;

    if (hasPreset() != other.hasPreset()) return false;
    if (hasPreset()) {
      if (!getPreset()
          .equals(other.getPreset())) return false;
    }
    if (!unknownFields.equals(other.unknownFields)) return false;
    return true;
  }

  @java.lang.Override
  public int hashCode() {
    if (memoizedHashCode != 0) {
      return memoizedHashCode;
    }
    int hash = 41;
    hash = (19 * hash) + getDescriptor().hashCode();
    if (hasPreset()) {
      hash = (37 * hash) + PRESET_FIELD_NUMBER;
      hash = (53 * hash) + getPreset().hashCode();
    }
    hash = (29 * hash) + unknownFields.hashCode();
    memoizedHashCode = hash;
    return hash;
  }

  public static protos.GetPresetResponse parseFrom(
      java.nio.ByteBuffer data)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data);
  }
  public static protos.GetPresetResponse parseFrom(
      java.nio.ByteBuffer data,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data, extensionRegistry);
  }
  public static protos.GetPresetResponse parseFrom(
      com.google.protobuf.ByteString data)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data);
  }
  public static protos.GetPresetResponse parseFrom(
      com.google.protobuf.ByteString data,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data, extensionRegistry);
  }
  public static protos.GetPresetResponse parseFrom(byte[] data)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data);
  }
  public static protos.GetPresetResponse parseFrom(
      byte[] data,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data, extensionRegistry);
  }
  public static protos.GetPresetResponse parseFrom(java.io.InputStream input)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input);
  }
  public static protos.GetPresetResponse parseFrom(
      java.io.InputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input, extensionRegistry);
  }
  public static protos.GetPresetResponse parseDelimitedFrom(java.io.InputStream input)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseDelimitedWithIOException(PARSER, input);
  }
  public static protos.GetPresetResponse parseDelimitedFrom(
      java.io.InputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseDelimitedWithIOException(PARSER, input, extensionRegistry);
  }
  public static protos.GetPresetResponse parseFrom(
      com.google.protobuf.CodedInputStream input)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input);
  }
  public static protos.GetPresetResponse parseFrom(
      com.google.protobuf.CodedInputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input, extensionRegistry);
  }

  @java.lang.Override
  public Builder newBuilderForType() { return newBuilder(); }
  public static Builder newBuilder() {
    return DEFAULT_INSTANCE.toBuilder();
  }
  public static Builder newBuilder(protos.GetPresetResponse prototype) {
    return DEFAULT_INSTANCE.toBuilder().mergeFrom(prototype);
  }
  @java.lang.Override
  public Builder toBuilder() {
    return this == DEFAULT_INSTANCE
        ? new Builder() : new Builder().mergeFrom(this);
  }

  @java.lang.Override
  protected Builder newBuilderForType(
      com.google.protobuf.GeneratedMessageV3.BuilderParent parent) {
    Builder builder = new Builder(parent);
    return builder;
  }
  /**
   * Protobuf type {@code GetPresetResponse}
   */
  public static final class Builder extends
      com.google.protobuf.GeneratedMessageV3.Builder<Builder> implements
      // @@protoc_insertion_point(builder_implements:GetPresetResponse)
      protos.GetPresetResponseOrBuilder {
    public static final com.google.protobuf.Descriptors.Descriptor
        getDescriptor() {
      return protos.Preset.internal_static_GetPresetResponse_descriptor;
    }

    @java.lang.Override
    protected com.google.protobuf.GeneratedMessageV3.FieldAccessorTable
        internalGetFieldAccessorTable() {
      return protos.Preset.internal_static_GetPresetResponse_fieldAccessorTable
          .ensureFieldAccessorsInitialized(
              protos.GetPresetResponse.class, protos.GetPresetResponse.Builder.class);
    }

    // Construct using protos.GetPresetResponse.newBuilder()
    private Builder() {
      maybeForceBuilderInitialization();
    }

    private Builder(
        com.google.protobuf.GeneratedMessageV3.BuilderParent parent) {
      super(parent);
      maybeForceBuilderInitialization();
    }
    private void maybeForceBuilderInitialization() {
      if (com.google.protobuf.GeneratedMessageV3
              .alwaysUseFieldBuilders) {
      }
    }
    @java.lang.Override
    public Builder clear() {
      super.clear();
      if (presetBuilder_ == null) {
        preset_ = null;
      } else {
        preset_ = null;
        presetBuilder_ = null;
      }
      return this;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.Descriptor
        getDescriptorForType() {
      return protos.Preset.internal_static_GetPresetResponse_descriptor;
    }

    @java.lang.Override
    public protos.GetPresetResponse getDefaultInstanceForType() {
      return protos.GetPresetResponse.getDefaultInstance();
    }

    @java.lang.Override
    public protos.GetPresetResponse build() {
      protos.GetPresetResponse result = buildPartial();
      if (!result.isInitialized()) {
        throw newUninitializedMessageException(result);
      }
      return result;
    }

    @java.lang.Override
    public protos.GetPresetResponse buildPartial() {
      protos.GetPresetResponse result = new protos.GetPresetResponse(this);
      if (presetBuilder_ == null) {
        result.preset_ = preset_;
      } else {
        result.preset_ = presetBuilder_.build();
      }
      onBuilt();
      return result;
    }

    @java.lang.Override
    public Builder clone() {
      return super.clone();
    }
    @java.lang.Override
    public Builder setField(
        com.google.protobuf.Descriptors.FieldDescriptor field,
        java.lang.Object value) {
      return super.setField(field, value);
    }
    @java.lang.Override
    public Builder clearField(
        com.google.protobuf.Descriptors.FieldDescriptor field) {
      return super.clearField(field);
    }
    @java.lang.Override
    public Builder clearOneof(
        com.google.protobuf.Descriptors.OneofDescriptor oneof) {
      return super.clearOneof(oneof);
    }
    @java.lang.Override
    public Builder setRepeatedField(
        com.google.protobuf.Descriptors.FieldDescriptor field,
        int index, java.lang.Object value) {
      return super.setRepeatedField(field, index, value);
    }
    @java.lang.Override
    public Builder addRepeatedField(
        com.google.protobuf.Descriptors.FieldDescriptor field,
        java.lang.Object value) {
      return super.addRepeatedField(field, value);
    }
    @java.lang.Override
    public Builder mergeFrom(com.google.protobuf.Message other) {
      if (other instanceof protos.GetPresetResponse) {
        return mergeFrom((protos.GetPresetResponse)other);
      } else {
        super.mergeFrom(other);
        return this;
      }
    }

    public Builder mergeFrom(protos.GetPresetResponse other) {
      if (other == protos.GetPresetResponse.getDefaultInstance()) return this;
      if (other.hasPreset()) {
        mergePreset(other.getPreset());
      }
      this.mergeUnknownFields(other.unknownFields);
      onChanged();
      return this;
    }

    @java.lang.Override
    public final boolean isInitialized() {
      return true;
    }

    @java.lang.Override
    public Builder mergeFrom(
        com.google.protobuf.CodedInputStream input,
        com.google.protobuf.ExtensionRegistryLite extensionRegistry)
        throws java.io.IOException {
      protos.GetPresetResponse parsedMessage = null;
      try {
        parsedMessage = PARSER.parsePartialFrom(input, extensionRegistry);
      } catch (com.google.protobuf.InvalidProtocolBufferException e) {
        parsedMessage = (protos.GetPresetResponse) e.getUnfinishedMessage();
        throw e.unwrapIOException();
      } finally {
        if (parsedMessage != null) {
          mergeFrom(parsedMessage);
        }
      }
      return this;
    }

    private protos.PresetObj preset_;
    private com.google.protobuf.SingleFieldBuilderV3<
        protos.PresetObj, protos.PresetObj.Builder, protos.PresetObjOrBuilder> presetBuilder_;
    /**
     * <code>.PresetObj preset = 1;</code>
     * @return Whether the preset field is set.
     */
    public boolean hasPreset() {
      return presetBuilder_ != null || preset_ != null;
    }
    /**
     * <code>.PresetObj preset = 1;</code>
     * @return The preset.
     */
    public protos.PresetObj getPreset() {
      if (presetBuilder_ == null) {
        return preset_ == null ? protos.PresetObj.getDefaultInstance() : preset_;
      } else {
        return presetBuilder_.getMessage();
      }
    }
    /**
     * <code>.PresetObj preset = 1;</code>
     */
    public Builder setPreset(protos.PresetObj value) {
      if (presetBuilder_ == null) {
        if (value == null) {
          throw new NullPointerException();
        }
        preset_ = value;
        onChanged();
      } else {
        presetBuilder_.setMessage(value);
      }

      return this;
    }
    /**
     * <code>.PresetObj preset = 1;</code>
     */
    public Builder setPreset(
        protos.PresetObj.Builder builderForValue) {
      if (presetBuilder_ == null) {
        preset_ = builderForValue.build();
        onChanged();
      } else {
        presetBuilder_.setMessage(builderForValue.build());
      }

      return this;
    }
    /**
     * <code>.PresetObj preset = 1;</code>
     */
    public Builder mergePreset(protos.PresetObj value) {
      if (presetBuilder_ == null) {
        if (preset_ != null) {
          preset_ =
            protos.PresetObj.newBuilder(preset_).mergeFrom(value).buildPartial();
        } else {
          preset_ = value;
        }
        onChanged();
      } else {
        presetBuilder_.mergeFrom(value);
      }

      return this;
    }
    /**
     * <code>.PresetObj preset = 1;</code>
     */
    public Builder clearPreset() {
      if (presetBuilder_ == null) {
        preset_ = null;
        onChanged();
      } else {
        preset_ = null;
        presetBuilder_ = null;
      }

      return this;
    }
    /**
     * <code>.PresetObj preset = 1;</code>
     */
    public protos.PresetObj.Builder getPresetBuilder() {
      
      onChanged();
      return getPresetFieldBuilder().getBuilder();
    }
    /**
     * <code>.PresetObj preset = 1;</code>
     */
    public protos.PresetObjOrBuilder getPresetOrBuilder() {
      if (presetBuilder_ != null) {
        return presetBuilder_.getMessageOrBuilder();
      } else {
        return preset_ == null ?
            protos.PresetObj.getDefaultInstance() : preset_;
      }
    }
    /**
     * <code>.PresetObj preset = 1;</code>
     */
    private com.google.protobuf.SingleFieldBuilderV3<
        protos.PresetObj, protos.PresetObj.Builder, protos.PresetObjOrBuilder> 
        getPresetFieldBuilder() {
      if (presetBuilder_ == null) {
        presetBuilder_ = new com.google.protobuf.SingleFieldBuilderV3<
            protos.PresetObj, protos.PresetObj.Builder, protos.PresetObjOrBuilder>(
                getPreset(),
                getParentForChildren(),
                isClean());
        preset_ = null;
      }
      return presetBuilder_;
    }
    @java.lang.Override
    public final Builder setUnknownFields(
        final com.google.protobuf.UnknownFieldSet unknownFields) {
      return super.setUnknownFields(unknownFields);
    }

    @java.lang.Override
    public final Builder mergeUnknownFields(
        final com.google.protobuf.UnknownFieldSet unknownFields) {
      return super.mergeUnknownFields(unknownFields);
    }


    // @@protoc_insertion_point(builder_scope:GetPresetResponse)
  }

  // @@protoc_insertion_point(class_scope:GetPresetResponse)
  private static final protos.GetPresetResponse DEFAULT_INSTANCE;
  static {
    DEFAULT_INSTANCE = new protos.GetPresetResponse();
  }

  public static protos.GetPresetResponse getDefaultInstance() {
    return DEFAULT_INSTANCE;
  }

  private static final com.google.protobuf.Parser<GetPresetResponse>
      PARSER = new com.google.protobuf.AbstractParser<GetPresetResponse>() {
    @java.lang.Override
    public GetPresetResponse parsePartialFrom(
        com.google.protobuf.CodedInputStream input,
        com.google.protobuf.ExtensionRegistryLite extensionRegistry)
        throws com.google.protobuf.InvalidProtocolBufferException {
      return new GetPresetResponse(input, extensionRegistry);
    }
  };

  public static com.google.protobuf.Parser<GetPresetResponse> parser() {
    return PARSER;
  }

  @java.lang.Override
  public com.google.protobuf.Parser<GetPresetResponse> getParserForType() {
    return PARSER;
  }

  @java.lang.Override
  public protos.GetPresetResponse getDefaultInstanceForType() {
    return DEFAULT_INSTANCE;
  }

}

