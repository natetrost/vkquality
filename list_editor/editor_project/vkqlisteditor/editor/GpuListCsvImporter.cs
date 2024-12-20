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
 
using System.Globalization;
using CsvHelper;

namespace vkqlisteditor.editor;

public class GpuListCsvImporter
{
    public static void ImportGpuListCsvFile(RuntimeData runtimeData, string csvPath, bool allowList)
    {
        if (allowList)
        {
            runtimeData.GpuPredictAllowList.Clear();
        }
        else
        {
            runtimeData.GpuPredictDenyList.Clear();
        }

        if (!File.Exists(csvPath)) return;

        using var reader = new StreamReader(csvPath);
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                var brandString = csv.GetField(CsvConstants.Brand);
                var gpuString = csv.GetField(CsvConstants.GpuName);
                var minApi = csv.GetField<int>(CsvConstants.MinApi);
                var minDriver = csv.GetField<uint>(CsvConstants.MinDriver);
                var deviceId = csv.GetField<uint>(CsvConstants.DeviceId);
                var vendorId = csv.GetField<uint>(CsvConstants.VendorId);
                if (allowList) runtimeData.GpuPredictAllowList.Add(new GpuPredictRecord(brandString, gpuString, deviceId, vendorId, minApi, minDriver));
                else runtimeData.GpuPredictDenyList.Add(new GpuPredictRecord(brandString, gpuString, deviceId, vendorId, minApi, minDriver));
            }
        }
    }
}
