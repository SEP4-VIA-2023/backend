package protos;

import static io.grpc.MethodDescriptor.generateFullMethodName;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.39.0)",
    comments = "Source: preset.proto")
public final class PresetServiceProtoGrpc {

  private PresetServiceProtoGrpc() {}

  public static final String SERVICE_NAME = "proto.PresetServiceProto";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<protos.CreatePresetRequest,
      protos.CreatePresetResponse> getCreatePresetMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "CreatePreset",
      requestType = protos.CreatePresetRequest.class,
      responseType = protos.CreatePresetResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<protos.CreatePresetRequest,
      protos.CreatePresetResponse> getCreatePresetMethod() {
    io.grpc.MethodDescriptor<protos.CreatePresetRequest, protos.CreatePresetResponse> getCreatePresetMethod;
    if ((getCreatePresetMethod = PresetServiceProtoGrpc.getCreatePresetMethod) == null) {
      synchronized (PresetServiceProtoGrpc.class) {
        if ((getCreatePresetMethod = PresetServiceProtoGrpc.getCreatePresetMethod) == null) {
          PresetServiceProtoGrpc.getCreatePresetMethod = getCreatePresetMethod =
              io.grpc.MethodDescriptor.<protos.CreatePresetRequest, protos.CreatePresetResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "CreatePreset"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  protos.CreatePresetRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  protos.CreatePresetResponse.getDefaultInstance()))
              .setSchemaDescriptor(new PresetServiceProtoMethodDescriptorSupplier("CreatePreset"))
              .build();
        }
      }
    }
    return getCreatePresetMethod;
  }

  private static volatile io.grpc.MethodDescriptor<protos.DeletePresetRequest,
      protos.DeletePresetResponse> getDeletePresetMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "DeletePreset",
      requestType = protos.DeletePresetRequest.class,
      responseType = protos.DeletePresetResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<protos.DeletePresetRequest,
      protos.DeletePresetResponse> getDeletePresetMethod() {
    io.grpc.MethodDescriptor<protos.DeletePresetRequest, protos.DeletePresetResponse> getDeletePresetMethod;
    if ((getDeletePresetMethod = PresetServiceProtoGrpc.getDeletePresetMethod) == null) {
      synchronized (PresetServiceProtoGrpc.class) {
        if ((getDeletePresetMethod = PresetServiceProtoGrpc.getDeletePresetMethod) == null) {
          PresetServiceProtoGrpc.getDeletePresetMethod = getDeletePresetMethod =
              io.grpc.MethodDescriptor.<protos.DeletePresetRequest, protos.DeletePresetResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "DeletePreset"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  protos.DeletePresetRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  protos.DeletePresetResponse.getDefaultInstance()))
              .setSchemaDescriptor(new PresetServiceProtoMethodDescriptorSupplier("DeletePreset"))
              .build();
        }
      }
    }
    return getDeletePresetMethod;
  }

  private static volatile io.grpc.MethodDescriptor<protos.GetPresetRequest,
      protos.GetPresetResponse> getGetPresetMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetPreset",
      requestType = protos.GetPresetRequest.class,
      responseType = protos.GetPresetResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<protos.GetPresetRequest,
      protos.GetPresetResponse> getGetPresetMethod() {
    io.grpc.MethodDescriptor<protos.GetPresetRequest, protos.GetPresetResponse> getGetPresetMethod;
    if ((getGetPresetMethod = PresetServiceProtoGrpc.getGetPresetMethod) == null) {
      synchronized (PresetServiceProtoGrpc.class) {
        if ((getGetPresetMethod = PresetServiceProtoGrpc.getGetPresetMethod) == null) {
          PresetServiceProtoGrpc.getGetPresetMethod = getGetPresetMethod =
              io.grpc.MethodDescriptor.<protos.GetPresetRequest, protos.GetPresetResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetPreset"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  protos.GetPresetRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  protos.GetPresetResponse.getDefaultInstance()))
              .setSchemaDescriptor(new PresetServiceProtoMethodDescriptorSupplier("GetPreset"))
              .build();
        }
      }
    }
    return getGetPresetMethod;
  }

  private static volatile io.grpc.MethodDescriptor<protos.ListPresetsRequest,
      protos.ListPresetsResponse> getListPresetsMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ListPresets",
      requestType = protos.ListPresetsRequest.class,
      responseType = protos.ListPresetsResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<protos.ListPresetsRequest,
      protos.ListPresetsResponse> getListPresetsMethod() {
    io.grpc.MethodDescriptor<protos.ListPresetsRequest, protos.ListPresetsResponse> getListPresetsMethod;
    if ((getListPresetsMethod = PresetServiceProtoGrpc.getListPresetsMethod) == null) {
      synchronized (PresetServiceProtoGrpc.class) {
        if ((getListPresetsMethod = PresetServiceProtoGrpc.getListPresetsMethod) == null) {
          PresetServiceProtoGrpc.getListPresetsMethod = getListPresetsMethod =
              io.grpc.MethodDescriptor.<protos.ListPresetsRequest, protos.ListPresetsResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "ListPresets"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  protos.ListPresetsRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  protos.ListPresetsResponse.getDefaultInstance()))
              .setSchemaDescriptor(new PresetServiceProtoMethodDescriptorSupplier("ListPresets"))
              .build();
        }
      }
    }
    return getListPresetsMethod;
  }

  private static volatile io.grpc.MethodDescriptor<protos.UpdatePresetRequest,
      protos.UpdatePresetResponse> getUpdatePresetMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "UpdatePreset",
      requestType = protos.UpdatePresetRequest.class,
      responseType = protos.UpdatePresetResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<protos.UpdatePresetRequest,
      protos.UpdatePresetResponse> getUpdatePresetMethod() {
    io.grpc.MethodDescriptor<protos.UpdatePresetRequest, protos.UpdatePresetResponse> getUpdatePresetMethod;
    if ((getUpdatePresetMethod = PresetServiceProtoGrpc.getUpdatePresetMethod) == null) {
      synchronized (PresetServiceProtoGrpc.class) {
        if ((getUpdatePresetMethod = PresetServiceProtoGrpc.getUpdatePresetMethod) == null) {
          PresetServiceProtoGrpc.getUpdatePresetMethod = getUpdatePresetMethod =
              io.grpc.MethodDescriptor.<protos.UpdatePresetRequest, protos.UpdatePresetResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "UpdatePreset"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  protos.UpdatePresetRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  protos.UpdatePresetResponse.getDefaultInstance()))
              .setSchemaDescriptor(new PresetServiceProtoMethodDescriptorSupplier("UpdatePreset"))
              .build();
        }
      }
    }
    return getUpdatePresetMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static PresetServiceProtoStub newStub(io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<PresetServiceProtoStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<PresetServiceProtoStub>() {
        @java.lang.Override
        public PresetServiceProtoStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new PresetServiceProtoStub(channel, callOptions);
        }
      };
    return PresetServiceProtoStub.newStub(factory, channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static PresetServiceProtoBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<PresetServiceProtoBlockingStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<PresetServiceProtoBlockingStub>() {
        @java.lang.Override
        public PresetServiceProtoBlockingStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new PresetServiceProtoBlockingStub(channel, callOptions);
        }
      };
    return PresetServiceProtoBlockingStub.newStub(factory, channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static PresetServiceProtoFutureStub newFutureStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<PresetServiceProtoFutureStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<PresetServiceProtoFutureStub>() {
        @java.lang.Override
        public PresetServiceProtoFutureStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new PresetServiceProtoFutureStub(channel, callOptions);
        }
      };
    return PresetServiceProtoFutureStub.newStub(factory, channel);
  }

  /**
   */
  public static abstract class PresetServiceProtoImplBase implements io.grpc.BindableService {

    /**
     */
    public void createPreset(protos.CreatePresetRequest request,
        io.grpc.stub.StreamObserver<protos.CreatePresetResponse> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getCreatePresetMethod(), responseObserver);
    }

    /**
     */
    public void deletePreset(protos.DeletePresetRequest request,
        io.grpc.stub.StreamObserver<protos.DeletePresetResponse> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getDeletePresetMethod(), responseObserver);
    }

    /**
     */
    public void getPreset(protos.GetPresetRequest request,
        io.grpc.stub.StreamObserver<protos.GetPresetResponse> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetPresetMethod(), responseObserver);
    }

    /**
     */
    public void listPresets(protos.ListPresetsRequest request,
        io.grpc.stub.StreamObserver<protos.ListPresetsResponse> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getListPresetsMethod(), responseObserver);
    }

    /**
     */
    public void updatePreset(protos.UpdatePresetRequest request,
        io.grpc.stub.StreamObserver<protos.UpdatePresetResponse> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getUpdatePresetMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getCreatePresetMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                protos.CreatePresetRequest,
                protos.CreatePresetResponse>(
                  this, METHODID_CREATE_PRESET)))
          .addMethod(
            getDeletePresetMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                protos.DeletePresetRequest,
                protos.DeletePresetResponse>(
                  this, METHODID_DELETE_PRESET)))
          .addMethod(
            getGetPresetMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                protos.GetPresetRequest,
                protos.GetPresetResponse>(
                  this, METHODID_GET_PRESET)))
          .addMethod(
            getListPresetsMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                protos.ListPresetsRequest,
                protos.ListPresetsResponse>(
                  this, METHODID_LIST_PRESETS)))
          .addMethod(
            getUpdatePresetMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                protos.UpdatePresetRequest,
                protos.UpdatePresetResponse>(
                  this, METHODID_UPDATE_PRESET)))
          .build();
    }
  }

  /**
   */
  public static final class PresetServiceProtoStub extends io.grpc.stub.AbstractAsyncStub<PresetServiceProtoStub> {
    private PresetServiceProtoStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected PresetServiceProtoStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new PresetServiceProtoStub(channel, callOptions);
    }

    /**
     */
    public void createPreset(protos.CreatePresetRequest request,
        io.grpc.stub.StreamObserver<protos.CreatePresetResponse> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getCreatePresetMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void deletePreset(protos.DeletePresetRequest request,
        io.grpc.stub.StreamObserver<protos.DeletePresetResponse> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getDeletePresetMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void getPreset(protos.GetPresetRequest request,
        io.grpc.stub.StreamObserver<protos.GetPresetResponse> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getGetPresetMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void listPresets(protos.ListPresetsRequest request,
        io.grpc.stub.StreamObserver<protos.ListPresetsResponse> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getListPresetsMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void updatePreset(protos.UpdatePresetRequest request,
        io.grpc.stub.StreamObserver<protos.UpdatePresetResponse> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getUpdatePresetMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class PresetServiceProtoBlockingStub extends io.grpc.stub.AbstractBlockingStub<PresetServiceProtoBlockingStub> {
    private PresetServiceProtoBlockingStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected PresetServiceProtoBlockingStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new PresetServiceProtoBlockingStub(channel, callOptions);
    }

    /**
     */
    public protos.CreatePresetResponse createPreset(protos.CreatePresetRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getCreatePresetMethod(), getCallOptions(), request);
    }

    /**
     */
    public protos.DeletePresetResponse deletePreset(protos.DeletePresetRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getDeletePresetMethod(), getCallOptions(), request);
    }

    /**
     */
    public protos.GetPresetResponse getPreset(protos.GetPresetRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getGetPresetMethod(), getCallOptions(), request);
    }

    /**
     */
    public protos.ListPresetsResponse listPresets(protos.ListPresetsRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getListPresetsMethod(), getCallOptions(), request);
    }

    /**
     */
    public protos.UpdatePresetResponse updatePreset(protos.UpdatePresetRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getUpdatePresetMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class PresetServiceProtoFutureStub extends io.grpc.stub.AbstractFutureStub<PresetServiceProtoFutureStub> {
    private PresetServiceProtoFutureStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected PresetServiceProtoFutureStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new PresetServiceProtoFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<protos.CreatePresetResponse> createPreset(
        protos.CreatePresetRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getCreatePresetMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<protos.DeletePresetResponse> deletePreset(
        protos.DeletePresetRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getDeletePresetMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<protos.GetPresetResponse> getPreset(
        protos.GetPresetRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getGetPresetMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<protos.ListPresetsResponse> listPresets(
        protos.ListPresetsRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getListPresetsMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<protos.UpdatePresetResponse> updatePreset(
        protos.UpdatePresetRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getUpdatePresetMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_CREATE_PRESET = 0;
  private static final int METHODID_DELETE_PRESET = 1;
  private static final int METHODID_GET_PRESET = 2;
  private static final int METHODID_LIST_PRESETS = 3;
  private static final int METHODID_UPDATE_PRESET = 4;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final PresetServiceProtoImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(PresetServiceProtoImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_CREATE_PRESET:
          serviceImpl.createPreset((protos.CreatePresetRequest) request,
              (io.grpc.stub.StreamObserver<protos.CreatePresetResponse>) responseObserver);
          break;
        case METHODID_DELETE_PRESET:
          serviceImpl.deletePreset((protos.DeletePresetRequest) request,
              (io.grpc.stub.StreamObserver<protos.DeletePresetResponse>) responseObserver);
          break;
        case METHODID_GET_PRESET:
          serviceImpl.getPreset((protos.GetPresetRequest) request,
              (io.grpc.stub.StreamObserver<protos.GetPresetResponse>) responseObserver);
          break;
        case METHODID_LIST_PRESETS:
          serviceImpl.listPresets((protos.ListPresetsRequest) request,
              (io.grpc.stub.StreamObserver<protos.ListPresetsResponse>) responseObserver);
          break;
        case METHODID_UPDATE_PRESET:
          serviceImpl.updatePreset((protos.UpdatePresetRequest) request,
              (io.grpc.stub.StreamObserver<protos.UpdatePresetResponse>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class PresetServiceProtoBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    PresetServiceProtoBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return protos.Preset.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("PresetServiceProto");
    }
  }

  private static final class PresetServiceProtoFileDescriptorSupplier
      extends PresetServiceProtoBaseDescriptorSupplier {
    PresetServiceProtoFileDescriptorSupplier() {}
  }

  private static final class PresetServiceProtoMethodDescriptorSupplier
      extends PresetServiceProtoBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    PresetServiceProtoMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (PresetServiceProtoGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new PresetServiceProtoFileDescriptorSupplier())
              .addMethod(getCreatePresetMethod())
              .addMethod(getDeletePresetMethod())
              .addMethod(getGetPresetMethod())
              .addMethod(getListPresetsMethod())
              .addMethod(getUpdatePresetMethod())
              .build();
        }
      }
    }
    return result;
  }
}
