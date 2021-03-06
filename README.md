# DeveGpuFanSpeedController
This project is made to control your Gpu fan speed by command line. (E.g. for bitcoin mining)

## Build status

| AppVeyor (Windows build) |
|:------------------------:|
| [![Build status](https://ci.appveyor.com/api/projects/status/8fo1i7jl7xmq2qo1?svg=true)](https://ci.appveyor.com/project/devedse/devegpufanspeedcontroller) |

## Instructions

Make sure MSI Afterburner is running, then run DeveGpuFanSpeedController.exe with the following arguments

| Argument Position | Values | Argument Description | Optional |
|:--:|:--:|:--:|:--:|
| 1 | 0-100 or AUTO | The desired fan speed | Required |
| 2 | Name of the process (E.g. mspaint) without .exe | The tool will keep the fan speed at the desired number and revert back to normal when the provided process ends | Optional |

Example (Will set the GPU fan speed to 100 while EthDcrMiner64.exe is running):

DeveGpuFanSpeedController.exe 100 EthDcrMiner64

## How it works

Basically I make use of the amazing library written by Nick (stangowner) on the Guru3D forums:

https://forums.guru3d.com/threads/msi-afterburner-net-class-library.339656/

## Donations

Ethereum: 0x0776C3770f2199edD7F214B18D602045ba295010
