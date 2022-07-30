#!/bin/sh

src_dir='src/'
builds_dir='builds/'

exe='SmolSnek.exe'

[ -d $builds_dir ] || mkdir $builds_dir && 
	find $src_dir -name "*.cs*" | xargs mcs -out:${builds_dir}/${exe}
