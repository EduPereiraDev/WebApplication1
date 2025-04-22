--
-- PostgreSQL database dump
--

-- Dumped from database version 17.4
-- Dumped by pg_dump version 17.4

-- Started on 2025-04-16 14:12:08

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 218 (class 1259 OID 16389)
-- Name: contato; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.contato (
    id integer NOT NULL,
    nome character varying(100),
    apelido character varying(100),
    cpf character varying(14),
    telefone character varying(15),
    email character varying(100),
    data_cadastro date DEFAULT CURRENT_DATE,
    data_ultima_alteracao date
);


ALTER TABLE public.contato OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16388)
-- Name: contato_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.contato_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.contato_id_seq OWNER TO postgres;

--
-- TOC entry 4898 (class 0 OID 0)
-- Dependencies: 217
-- Name: contato_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.contato_id_seq OWNED BY public.contato.id;


--
-- TOC entry 4742 (class 2604 OID 16392)
-- Name: contato id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contato ALTER COLUMN id SET DEFAULT nextval('public.contato_id_seq'::regclass);


--
-- TOC entry 4892 (class 0 OID 16389)
-- Dependencies: 218
-- Data for Name: contato; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.contato (id, nome, apelido, cpf, telefone, email, data_cadastro, data_ultima_alteracao) FROM stdin;
4	sadas	asdasd	123,123,123-12	(12) 31231-2312	saddad@gmail.com	2025-04-01	2025-04-16
1	asdasd	sadasd	123,123,123-13	(12) 31231-231	asda@gmai,ckasd	2025-04-16	2025-04-16
\.


--
-- TOC entry 4899 (class 0 OID 0)
-- Dependencies: 217
-- Name: contato_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.contato_id_seq', 4, true);


--
-- TOC entry 4745 (class 2606 OID 16395)
-- Name: contato contato_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contato
    ADD CONSTRAINT contato_pkey PRIMARY KEY (id);


-- Completed on 2025-04-16 14:12:08

--
-- PostgreSQL database dump complete
--

