clear;
%读入标签名称
f = fopen('vericode-map.txt');
labelList = fscanf(f, '%s');
fclose(f);
%labelList=importdata('vericode-map.txt');

%设置为cpu模式，gpu模式不可用，除非重新编译
caffe.set_mode_cpu();
%gpu_id=0;
%caffe.set_mode_gpu();	
%caffe.set_device(gpu_id);

%载入网络
net = caffe.Net('vericode-nin.prototxt', 'nin_iter_5000.caffemodel','test');
img = imread('1A2I.bmp');

%因为网络要求图像是224*224的，所以这里需要resize
img = imresize(img, [224 224]);

%因为caffe是BGR的，matlab是RGB的，所以要切换通道
img = img(:, :, [3, 2, 1]);

%因为caffe的排列方式是行排列，即内存数据的前n个字节全是一行的数据，而matlab正好反过来，是列数据
%所以这里要把行列调换
img = permute(img, [2, 1, 3]);

%调用网络做识别
result = net.forward({img});
labelResult = '';

%因为是多个标签的输出，所以循环取出来
for i = 1:size(result, 1)
    [conf, label] = max(result{i});
    labelResult = [labelResult labelList(label)];
end
sprintf('识别结果：%s', labelResult)