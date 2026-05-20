import React, { useEffect, useState, useRef } from "react";
import { Outlet, useLocation } from "react-router";

export function AppLayout() {
  const [scale, setScale] = useState(1);
  const contentRef = useRef<HTMLDivElement>(null);
  const [contentHeight, setContentHeight] = useState<number>(0);
  const location = useLocation();

  useEffect(() => {
    const handleResize = () => {
      const screenWidth = window.innerWidth;
      if (screenWidth < 1920) {
        setScale(screenWidth / 1920);
      } else {
        setScale(1);
      }
    };

    handleResize();
    window.addEventListener("resize", handleResize);
    return () => window.removeEventListener("resize", handleResize);
  }, []);

  useEffect(() => {
    if (!contentRef.current) return;
    
    const updateHeight = () => {
      if (contentRef.current) {
        // scrollHeight returns the actual unscaled height of the content
        setContentHeight(contentRef.current.scrollHeight);
      }
    };

    const observer = new ResizeObserver(() => {
      updateHeight();
    });
    
    observer.observe(contentRef.current);
    updateHeight();
    
    return () => observer.disconnect();
  }, [location.pathname]);

  return (
    <div className="w-full min-h-screen bg-white overflow-x-hidden flex justify-center">
      <div 
        className="relative shrink-0"
        style={{ 
          width: `${1920 * scale}px`, 
          height: contentHeight > 0 ? contentHeight * scale : 'auto' 
        }}
      >
        <div 
          ref={contentRef}
          className="absolute top-0 left-0 w-[1920px] origin-top-left bg-white"
          style={{ transform: `scale(${scale})` }}
        >
          <Outlet />
        </div>
      </div>
    </div>
  );
}