// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: preset.proto

package protos;

public interface ListPresetsResponseOrBuilder extends
    // @@protoc_insertion_point(interface_extends:ListPresetsResponse)
    com.google.protobuf.MessageOrBuilder {

  /**
   * <code>repeated .PresetObj presets = 1;</code>
   */
  java.util.List<protos.PresetObj> 
      getPresetsList();
  /**
   * <code>repeated .PresetObj presets = 1;</code>
   */
  protos.PresetObj getPresets(int index);
  /**
   * <code>repeated .PresetObj presets = 1;</code>
   */
  int getPresetsCount();
  /**
   * <code>repeated .PresetObj presets = 1;</code>
   */
  java.util.List<? extends protos.PresetObjOrBuilder> 
      getPresetsOrBuilderList();
  /**
   * <code>repeated .PresetObj presets = 1;</code>
   */
  protos.PresetObjOrBuilder getPresetsOrBuilder(
      int index);
}
