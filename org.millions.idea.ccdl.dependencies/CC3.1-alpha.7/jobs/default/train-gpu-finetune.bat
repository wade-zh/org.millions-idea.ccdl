@echo off
"..\..\bin-gpu-cuda8.0\caffe.exe" train --solver=solver.prototxt --weights=models/_iter_100000.caffemodel
pause