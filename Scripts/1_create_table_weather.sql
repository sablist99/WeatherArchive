CREATE TABLE Weather (
	id SERIAL PRIMARY KEY,				-- Уникальный идентификатор записи 
	date DATE NOT NULL,					-- Дата наблюдения
	time TIME NOT NULL,					-- Время наблюдения
	temperature DECIMAL(4, 1) NOT NULL,	-- Температура воздуха (в цельсиях)
	humidity SMALLINT NOT NULL,			-- Относительная влажность (в процентах)
	dew_point DECIMAL(4, 1) NOT NULL,	-- Точка росы (в цельсиях)
	pressure SMALLINT NOT NULL,			-- Атмосферное давление (в мм рт.ст.)
	wind_direction VARCHAR(10),			-- Направление ветра (например, З,ЮЗ,штиль)
	wind_speed DECIMAL(4, 1),			-- Скорость ветра (в м/с)
	cloudiness SMALLINT,				-- Облачность (в %)
	cloud_base_height INT,				-- Нижняя граница облачности (в м)
	horizontal_visibility DECIMAL(4, 1),-- Горизонтальная видимость (в км)
	weather_phenomena VARCHAR(1000)		-- Погодные явления (например, Дымка)
);
