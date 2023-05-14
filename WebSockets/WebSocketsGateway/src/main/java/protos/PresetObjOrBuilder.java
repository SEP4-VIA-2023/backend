// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: preset.proto

package protos;

public interface PresetObjOrBuilder extends
    // @@protoc_insertion_point(interface_extends:PresetObj)
    com.google.protobuf.MessageOrBuilder {

  /**
   * <code>int32 Id = 1;</code>
   * @return The id.
   */
  int getId();

  /**
   * <code>string Name = 2;</code>
   * @return The name.
   */
  java.lang.String getName();
  /**
   * <code>string Name = 2;</code>
   * @return The bytes for name.
   */
  com.google.protobuf.ByteString
      getNameBytes();

  /**
   * <code>float MinHumidity = 3;</code>
   * @return The minHumidity.
   */
  float getMinHumidity();

  /**
   * <code>float MaxHumidity = 4;</code>
   * @return The maxHumidity.
   */
  float getMaxHumidity();

  /**
   * <code>float MinCo2 = 5;</code>
   * @return The minCo2.
   */
  float getMinCo2();

  /**
   * <code>float MaxCo2 = 6;</code>
   * @return The maxCo2.
   */
  float getMaxCo2();

  /**
   * <code>float MinTemperature = 7;</code>
   * @return The minTemperature.
   */
  float getMinTemperature();

  /**
   * <code>float MaxTemperature = 8;</code>
   * @return The maxTemperature.
   */
  float getMaxTemperature();

  /**
   * <code>string deviceId = 9;</code>
   * @return The deviceId.
   */
  java.lang.String getDeviceId();
  /**
   * <code>string deviceId = 9;</code>
   * @return The bytes for deviceId.
   */
  com.google.protobuf.ByteString
      getDeviceIdBytes();
}
