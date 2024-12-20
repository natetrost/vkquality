/*
 * Copyright 2024 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace vkqlisteditor.editor;

public class DeviceListProject
{
    public int ProjectSchemaVersion { get; set; }
    public int ExportedListFileVersion { get; set; }
    public int MinApiForFutureRecommendation { get; set; }
    public DeviceAllowListRecord[]? DeviceAllowList { get; set; }
    public DriverFingerprintRecord[]? DriverAllowList { get; set; }
    public DriverFingerprintRecord[]? DriverDenyList { get; set; }
    public GpuPredictRecord[]? GpuPredictAllowList { get; set; }
    public GpuPredictRecord[]? GpuPredictDenyList { get; set; }
}
