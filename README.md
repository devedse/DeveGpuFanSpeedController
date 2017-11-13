# DeveGpuFanSpeedController
This project is made to control your Gpu fan speed by command line. (E.g. for bitcoin mining)

## Build status

| AppVeyor (Windows build) |
|:------------------------:|
| [![Build status](https://ci.appveyor.com/api/projects/status/8fo1i7jl7xmq2qo1?svg=true)](https://ci.appveyor.com/project/devedse/devegpufanspeedcontroller) |

## Instructions

Run DeveGpuFanSpeedController.exe with the following arguments

|| Argument Position || Values || Argument Description || Optional ||
| 1 | 0-100 or AUTO | The desired fan speed | Required |
| 2 | Name of the process (E.g. mspaint) without .exe | The tool will keep the fan speed at the desired number and revert back to normal when the provided process ends | Optional |
